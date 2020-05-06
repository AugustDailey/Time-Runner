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

let spawnPlayer xy (cm:ControlModel.T) (gs:GameState.T) =
    let player = {
        CommonEntityData.id = gs.nextid;
        CommonEntityData.position = xy;
        CommonEntityData.speed = 10.0;
        CommonEntityData.direction = 0.0;
        CommonEntityData.isMoving = false;
        CommonEntityData.data = EntityType.Player {
            melee = TestMeleeWeapon.createWeapon ();
            ranged = TestRangedWeapon.createWeapon ();
            roll = NullWeapon.createWeapon ();
            active = CameraShakeWeapon.createWeapon ();
            items = [];
            effects = [];
            controlModel = cm
        }
        CommonEntityData.iframes = 0.0;
        CommonEntityData.sprite = "yay"
    }
    let newEntities = Map.add gs.nextid player gs.entities 
    { gs with entities = newEntities } |> GameStateUtils.modifyForSpawn

let collideWithPlayer (self:CommonEntityData.T) (other:CommonEntityData.T) (gs:GameState.T) =
    UnityEngine.Debug.Log("Player collided with another Player")
    gs
    
let collideWithEnemy (self:CommonEntityData.T) (other:CommonEntityData.T) (gs:GameState.T) =
    let player = GameStateUtils.getEntityByID gs self.id
    match player.iframes with
    | 0.0 when player.iframes <= 0.0 ->
        let iframesGs = { gs with entities = Map.add player.id { player with iframes = 0.5 } gs.entities }
        GameDataUtils.decreaseTime 5.0 iframesGs
    | _ ->
        gs

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
    let player = GameStateUtils.getEntityByID gs self.id
    match other.data with
    | EntityType.Projectile proj ->
        match proj.team with
        | 0 ->
            gs
        | _ ->
            match player.iframes <= 0.0 with
            | true ->
                let newProj = { proj with health = proj.health - 1}
                let projDamage = proj.damage |> float
                let iframesGs = { gs with entities = Map.add player.id { player with iframes = 0.5 } gs.entities }
                let gsWithReducedTime = GameDataUtils.decreaseTime projDamage iframesGs
                match newProj.health with
                | 0 ->
                    let gsWithoutProj = GameStateUtils.markEntityForDestruction gsWithReducedTime other.id
                    { gsWithoutProj with entities = Map.add other.id { other with data = EntityType.Projectile newProj } gsWithoutProj.entities}
                | _ ->
                    { gsWithReducedTime with entities = Map.add other.id { other with data = EntityType.Projectile newProj } gsWithReducedTime.entities}
            | false ->
                gs

let removeNonPlayerEntities gs eid (data:CommonEntityData.T) =
    match data.data with
    | EntityType.Player player -> // don't remove players
        gs
    | _ -> // remove all other entities
        GameStateUtils.markEntityForDestruction gs eid

let collideWithStairs (gs:GameState.T) =
    match gs.level.complete with // need this check to prevent colliding with stairs twice
    | false ->
        let newGs = Map.fold removeNonPlayerEntities gs gs.entities
        // mark level as complete and increment floor number
        { newGs with level = { newGs.level with complete = true } ; gamedata = { newGs.gamedata with floor = newGs.gamedata.floor + 1; floortime = 0.0 } }
    | true ->
        gs

let collideWithNothing (self:CommonEntityData.T) (other:CommonEntityData.T) (gs:GameState.T) =
    gs

let tickWeaponCooldown delta id (weaponData:WeaponData.T) (gs:GameState.T) =
    let entityData = GameStateUtils.getEntityByID gs id
    match entityData.data with
    | EntityType.Player playerData ->
        let newWeapon = { weaponData with cooldown = max (weaponData.cooldown - delta) 0.0 }
        let newPlayerData = match weaponData.weaponType with
        | WeaponData.Category.Melee ->
            { playerData with melee = newWeapon }
        | WeaponData.Category.Ranged ->
            { playerData with ranged = newWeapon }
        | WeaponData.Category.Roll ->
            { playerData with roll = newWeapon }
        | WeaponData.Category.Active ->
            { playerData with active = newWeapon }
        let newEntityData = { entityData with data = EntityType.Player newPlayerData }
        { gs with entities = Map.add id newEntityData gs.entities }
    | _ ->
        gs

