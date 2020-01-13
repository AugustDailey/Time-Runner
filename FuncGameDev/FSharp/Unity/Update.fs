namespace FSharp.Unity

open UnityEngine

type Updater() = 
    inherit MonoBehaviour()

    //[<SerializeField>]
    //let mutable gameObjects: GameObjectWrapper.T list = List.empty

    // TODO: THIS VARIABLE SHOULD BE REMOVED ONCE WE COMPLETE TIMER DISPLAY
    let mutable lastTime = GameState.instance.gamedata.time |> int

    member this.Start() =
        //InputConfigurationService.Read
        let gs = GameState.instance
        //let controlModel = Map.find 1 InputConfigurationService.PlayersToControls
        let controlModel = {
            ControlModel.down = "down";
            ControlModel.up = "up";
            ControlModel.left = "left";
            ControlModel.right = "right"
        }
        let tempWeapon = {
            WeaponData.weaponName = "Temp Weapon";
            WeaponData.cooldown = 0.4;
            WeaponData.damage = 35;
            WeaponData.effects = [];
            WeaponData.weaponType = WeaponData.Category.Melee;
        }
        let player1 = {
            CommonEntityData.id = 1;
            CommonEntityData.position = (2.0, 1.0);
            CommonEntityData.speed = 10.0;
            CommonEntityData.data = EntityType.Player {
                melee = tempWeapon;
                ranged = tempWeapon;
                roll = tempWeapon;
                active = tempWeapon;
                items = [];
                effects = [];
                controlModel = controlModel
            }
            CommonEntityData.sprite = "yay"
        }
        let enemy1 = {
            CommonEntityData.id = 2;
            CommonEntityData.position = (-2.0, -1.0);
            CommonEntityData.speed = 5.0;
            CommonEntityData.data = EntityType.Enemy {
                health = 10;
                weapon = tempWeapon;
                effects = [];
                enemyType = "Tracker"
            }
            CommonEntityData.sprite = "yay"
        }
        let entitiesMap = 
            Map.empty.
                Add(player1.id, player1).
                Add(enemy1.id, enemy1)
        let spawnIds = [1 ; 2]
        GameState.instance <- { gs with entities = entitiesMap; spawnIds = spawnIds }
        //GameState.instance <- { gs with entities = Map.add player1.id player1 gs.entities; spawnIds = player1.id::gs.spawnIds }
        ()

    member this.Update() =
        
        // TODO: THIS BLOCK SHOULD BE REMOVED ONCE WE COMPLETE TIMER DISPLAY
        // it's just here so that we only print each time increment once rather than spamming the console with it
        let time = GameState.instance.gamedata.time |> int
        if time <> lastTime then Debug.Log("TIME: " + time.ToString());
        lastTime <- time

        Time.deltaTime |> float |> GameDataUtils.decreaseTime |> Commands.addCommand
        GameState.instance.entities |> Map.iter UserController.tryQueryInput
        GameState.instance.entities |> Map.iter EnemyAIScript.callEnemyAI
        GameState.instance <- Commands.executeAllCommands GameState.instance
        UpdaterDispatcher.updateAllGameObjects GameState.instance GameObjectWrapper.wrappers
        let newGameObjects = Spawner.spawnGameObjects GameState.instance
        GameObjectWrapper.wrappers <- List.append GameObjectWrapper.wrappers newGameObjects
        ()
