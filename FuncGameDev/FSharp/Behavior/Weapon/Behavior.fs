module WeaponBehavior

//attack with the weapon
//wid: int = id of the weapon
//eid: int = id of the weapon owner
//xy: float = xy coordinates of the unit holding the weapon
//degrees: float = the degree direction that the unit is facing
//gs: GameState = the current gamestate
//returns a function that takes a gamestate and returns a gamestate
let attack wid eid xy degrees (gs:GameState.T) =
    let weaponData = GameStateUtils.getEntityByID wid gs
    match weaponData.entity with
    | EntityType.Weapon weapon ->
        let entityData = GameStateUtils.getEntityByID eid gs
        let weaponBehavior = Map.find weapon.behaviorID WeaponBehaviorTable.Instance
        weaponBehavior.attack weapon entityData xy degrees gs
    | _ ->
        gs