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
            WeaponData.behaviorID = 0
        }
        let weapon1 = {
            CommonEntityData.id = 3;
            CommonEntityData.position = (0.0, 1.0);
            CommonEntityData.speed = 0.0;
            CommonEntityData.data = EntityType.Weapon {
                WeaponData.weaponName = "Ranged Weapon";
                WeaponData.cooldown = 0.2;
                WeaponData.damage = 5;
                WeaponData.effects = [];
                WeaponData.weaponType = WeaponData.Category.Ranged;
                WeaponData.behaviorID = 0
            };
            CommonEntityData.sprite = "yay"
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
        let item1 = {
            CommonEntityData.id = 4;
            CommonEntityData.position = (-3.0, 2.5);
            CommonEntityData.speed = 0.0;
            CommonEntityData.data = EntityType.Item {
                ItemData.itemName = "Time";
                ItemData.behaviorID = 1
            }
            CommonEntityData.sprite = "yay"
        }
        let projectile1 = {
            CommonEntityData.id = 5
            CommonEntityData.position = (-3.0, -2.5)
            CommonEntityData.speed = 0.0
            CommonEntityData.data = EntityType.Projectile {
                damage = 5
                effects = []
                lifespan = 100.0
                degrees = 0.0
                behaviorID = 1
                health = 1
                team = 0
            }
            CommonEntityData.sprite = "yay"
        }
        let projectile2 = {
            CommonEntityData.id = 6
            CommonEntityData.position = (3.0, -2.5)
            CommonEntityData.speed = 0.0
            CommonEntityData.data = EntityType.Projectile {
                damage = 5
                effects = []
                lifespan = 100.0
                degrees = 0.0
                behaviorID = 1
                health = 2
                team = 1
            }
            CommonEntityData.sprite = "yay"
        }
        let entitiesMap = 
            Map.empty.
                Add(player1.id, player1).
                Add(enemy1.id, enemy1).
                Add(weapon1.id, weapon1).
                Add(item1.id, item1).
                Add(projectile1.id, projectile1).
                Add(projectile2.id, projectile2)
        let spawnIds = [1 ; 2 ; 3 ; 4 ; 5 ; 6]
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
        newGameObjects |> Map.iter (fun key value -> GameObjectWrapper.addWrapper value)
        GameState.instance <- GameStateUtils.removeMarkedEntities GameState.instance
        GameState.instance.killIds |> Destroyer.update
        ()
