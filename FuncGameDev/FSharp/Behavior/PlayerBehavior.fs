module PlayerBehavior

//Use equipped weapon
//pid: int = id of player (1-4)
//weapontype: WeaponType = category of weapon to use
//gs: GameState = the current gamestate
//returns a function that takes a gamestate and returns a gamestate
let useWeapon pid weapontype gs =
    match weapontype with
    | WeaponData.Category.Melee -> printfn "Player Using Melee"
    | WeaponData.Category.Ranged -> printfn "Player Using Ranged"
    | WeaponData.Category.Roll -> printfn "Player Using Roll"
    | WeaponData.Category.Active -> printfn "Player Using Active"
    gs

let spawnPlayer xy (gs:GameState.T) =
    let tempWeapon = {
        WeaponData.weaponName = "Temp Weapon";
        WeaponData.cooldown = 0.4;
        WeaponData.damage = 35;
        WeaponData.effects = [];
        WeaponData.weaponType = WeaponData.Category.Melee;
        WeaponData.behaviorID = 0
    }
    let controlModel = {
        ControlModel.down = "down";
        ControlModel.up = "up";
        ControlModel.left = "left";
        ControlModel.right = "right";
        ControlModel.melee = "n";
        ControlModel.range = "k";
        ControlModel.active = "l";
        ControlModel.dodge = "m"
    }
    let player = {
        CommonEntityData.id = gs.nextid;
        CommonEntityData.position = xy;
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
    let newEntities = Map.add gs.nextid player gs.entities 
    { gs with entities = newEntities } |> GameStateUtils.modifyForSpawn

let collideWithPlayer (self:CommonEntityData.T) (other:CommonEntityData.T) (gs:GameState.T) =
    UnityEngine.Debug.Log("Player collided with another Player")
    gs
    
let collideWithEnemy (self:CommonEntityData.T) (other:CommonEntityData.T) (gs:GameState.T) =
    GameDataUtils.decreaseTime 5.0 gs

let addWeaponToPlayer (playerData:CommonEntityData.T) (player:PlayerData.T) (weapon:WeaponData.T) (gs:GameState.T) =
    let newPlayer = match weapon.weaponType with
    | WeaponData.Category.Melee -> { player with melee = weapon }
    | WeaponData.Category.Ranged -> { player with ranged = weapon }
    | WeaponData.Category.Roll -> { player with roll = weapon }
    | WeaponData.Category.Active -> { player with active = weapon }
    let newPlayerData = { playerData with data = EntityType.Player newPlayer }
    { gs with entities = Map.add newPlayerData.id newPlayerData gs.entities }
    
let collideWithWeapon (self:CommonEntityData.T) (other:CommonEntityData.T) (gs:GameState.T) =
    match other.data with
    | EntityType.Weapon weapon ->
        match self.data with
        | EntityType.Player player ->
            let newGs = addWeaponToPlayer self player weapon gs
            GameStateUtils.markEntityForDestruction newGs other.id
        | _ ->
            gs
    | _ ->
        gs
    
let collideWithItem (self:CommonEntityData.T) (other:CommonEntityData.T) (gs:GameState.T) =
    match other.data with
    | EntityType.Item item ->
        let itemBehavior = Map.find item.behaviorID ItemBehaviorTable.Instance
        let newGs = itemBehavior.onpickup other self gs
        GameStateUtils.markEntityForDestruction newGs other.id
    | _ ->
        gs
    
let collideWithProjectile (self:CommonEntityData.T) (other:CommonEntityData.T) (gs:GameState.T) =
    match other.data with
    | EntityType.Projectile proj ->
        match proj.team with
        | 0 ->
            gs
        | _ ->
            let newProj = { proj with health = proj.health - 1}
            let projDamage = proj.damage |> float
            let gsWithReducedTime = GameDataUtils.decreaseTime projDamage gs
            match newProj.health with
            | 0 ->
                let gsWithoutProj = GameStateUtils.markEntityForDestruction gsWithReducedTime other.id
                { gsWithoutProj with entities = Map.add other.id { other with data = EntityType.Projectile newProj } gsWithoutProj.entities}
            | _ ->
                { gsWithReducedTime with entities = Map.add other.id { other with data = EntityType.Projectile newProj } gsWithReducedTime.entities}

let collideWithNothing (self:CommonEntityData.T) (other:CommonEntityData.T) (gs:GameState.T) =
    gs


