module WeaponBehavior

//attack with the wapon
//weapon: WeaponData.T = the weapon to attack with
//eid: int = id of the weapon owner
//xy: float*float = xy coordinates of the unit holding the weapon
//degrees: float = the degree direction that the unit is facing
//gs: GameState = the current gamestate
//returns a function that takes a gamestate and returns a gamestate
let attack (weapon:WeaponData.T) eid xy degrees (gs:GameState.T) =
    let entityData = GameStateUtils.getEntityByID gs eid
    let weaponBehavior = Map.find weapon.behaviorID WeaponBehaviorTable.Instance
    weaponBehavior.attack weapon entityData xy degrees gs

let spawn xy bid (gs:GameState.T) =
    let weaponBehavior = Map.find bid WeaponBehaviorTable.Instance
    weaponBehavior.spawn xy gs |> GameStateUtils.modifyForSpawn