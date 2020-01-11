namespace FSharp.Unity

open UnityEngine

type Updater() = 
    inherit MonoBehaviour()

    [<SerializeField>]
    let mutable gameObjects: GameObject list = List.empty

    member this.Start() =
        let gs = GameState.instance
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
                effects = []
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
                effects = []
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
        let gs = GameState.instance
        Commands.executeAllCommands Commands.commands gs
        UpdaterDispatcher.updateAllGameObjects gs gameObjects
        Spawner.spawnGameObjects gs
        ()
