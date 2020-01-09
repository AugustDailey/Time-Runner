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
            CommonEntityData.position = (150.0,250.0);
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
        GameState.instance <- { gs with entities = Map.add player1.id player1 gs.entities }
        //let go = gameObjects.Item(0)
        Spawner.spawnEntity(gs)

        //spawn object
        let player = GameObject.Instantiate(Resources.Load<GameObject>("Player"))
        let enemy = GameObject.Instantiate(Resources.Load<GameObject>("Enemy"))
        let item = GameObject.Instantiate(Resources.Load<GameObject>("Item"))
        let weapon = GameObject.Instantiate(Resources.Load<GameObject>("Weapon"))
        //Add Components
        Debug.Log("Spawned Hardcoded GOs")
        ()

    member this.Update() =
        let gs = GameState.instance
        Commands.executeAllCommands Commands.commands gs
        UpdaterDispatcher.updateAllGameObjects gs gameObjects
        ()
