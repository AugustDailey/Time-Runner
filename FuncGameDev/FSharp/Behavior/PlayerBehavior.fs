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
    UnityEngine.Debug.Log("Player collided with an Enemy")
    gs
    
let collideWithWeapon (self:CommonEntityData.T) (other:CommonEntityData.T) (gs:GameState.T) =
    UnityEngine.Debug.Log("Player collided with a Weapon")
    gs
    
let collideWithItem (self:CommonEntityData.T) (other:CommonEntityData.T) (gs:GameState.T) =
    UnityEngine.Debug.Log("Player collided with an Item")
    gs
    
let collideWithProjectile (self:CommonEntityData.T) (other:CommonEntityData.T) (gs:GameState.T) =
    UnityEngine.Debug.Log("Player collided with a Projectile")
    gs
