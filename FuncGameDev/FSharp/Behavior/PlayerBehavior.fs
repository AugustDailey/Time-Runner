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
    UnityEngine.Debug.Log(self)
    match other.data with
    | EntityType.Weapon weapon ->
        match self.data with
        | EntityType.Player player ->
            let newGs = addWeaponToPlayer self player weapon gs
            UnityEngine.Debug.Log(newGs)
            GameStateUtils.markEntityForDestruction newGs other.id
        | _ ->
            UnityEngine.Debug.Log("CASE 3");
            gs
    | _ ->
        gs
    
let collideWithItem (self:CommonEntityData.T) (other:CommonEntityData.T) (gs:GameState.T) =
    UnityEngine.Debug.Log("Player collided with an Item")
    gs
    
let collideWithProjectile (self:CommonEntityData.T) (other:CommonEntityData.T) (gs:GameState.T) =
    UnityEngine.Debug.Log("Player collided with a Projectile")
    gs
