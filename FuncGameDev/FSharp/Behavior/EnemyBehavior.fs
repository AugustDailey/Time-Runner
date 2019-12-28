module EnemyBehavior

//Use equipped weapon
//eid: int = id of enemy
//gs: GameState = the current gamestate
//returns a function that takes a gamestate and returns a gamestate
let useWeapon eid (gs: GameState.T) =
    let entityOption = gs.entities.TryFind(eid)
    match entityOption with
    | _ ->
        let entity = entityOption.Value.data
        match entity with
        | EntityType.Weapon weapon -> 
            let weaponType = weapon.weaponType
            match weaponType with
            | WeaponData.Category.Melee -> printfn "Player Using Melee"
            | WeaponData.Category.Ranged -> printfn "Player Using Ranged"
            | WeaponData.Category.Roll -> printfn "Player Using Roll"
            | WeaponData.Category.Active -> printfn "Player Using Active"
    gs