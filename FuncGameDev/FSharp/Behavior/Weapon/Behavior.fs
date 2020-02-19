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
    match (weapon.cooldown <= 0.0) with
    | true ->
        let weaponBehavior = Map.find weapon.behaviorID WeaponBehaviorTable.Instance
        let newGs = weaponBehavior.attack weapon entityData xy degrees gs
        let newWeapon = { weapon with cooldown = weapon.firerate }
        let newEntity = match entityData.data with
            | EntityType.Player player ->
                match weapon.weaponType with
                | WeaponData.Category.Melee ->
                    { entityData with data = EntityType.Player { player with melee = newWeapon } }
                | WeaponData.Category.Ranged ->
                    { entityData with data = EntityType.Player { player with ranged = newWeapon } }
                | WeaponData.Category.Roll ->
                    { entityData with data = EntityType.Player { player with roll = newWeapon } }
                | WeaponData.Category.Active ->
                    { entityData with data = EntityType.Player { player with active = newWeapon } }
            | EntityType.Enemy enemy ->
                { entityData with data = EntityType.Enemy { enemy with weapon = newWeapon } }
            | _ ->
                entityData
        { newGs with entities = Map.add eid newEntity newGs.entities }
    | false ->
        gs

let spawn xy bid (gs:GameState.T) =
    let weaponBehavior = Map.find bid WeaponBehaviorTable.Instance
    weaponBehavior.spawn xy gs |> GameStateUtils.modifyForSpawn
