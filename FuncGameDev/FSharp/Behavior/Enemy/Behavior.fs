module EnemyBehavior

let spawn xy bid (gs:GameState.T) =
    match bid with
    | 0 ->
        gs
    | _ ->
        let enemyBehavior = Map.find bid EnemyBehaviorTable.Instance
        enemyBehavior.spawn xy bid gs |> GameStateUtils.modifyForSpawn

let attack eid (gs:GameState.T) =
    let enemy = Map.find eid gs.entities
    match enemy.data with
    | EntityType.Enemy data ->
        WeaponBehavior.attack data.weapon eid enemy.position enemy.direction gs
    | _ ->
        gs

let updateSpeed eid newSpeed (gs:GameState.T) =
    let enemy = Map.find eid gs.entities
    let newEnemy = { enemy with speed = newSpeed }
    { gs with entities = Map.add eid newEnemy gs.entities }

let tickWeaponCooldown delta id (weaponData:WeaponData.T) (gs:GameState.T) =
    let entityData = GameStateUtils.getEntityByID gs id
    match entityData.data with
    | EntityType.Enemy enemyData ->
        let newWeaponData = { weaponData with cooldown = max (weaponData.cooldown - delta) 0.0 }
        let newEnemyData = { enemyData with weapon = newWeaponData }
        let newEntityData = { entityData with data = EntityType.Enemy newEnemyData }
        { gs with entities = Map.add id newEntityData gs.entities }
    | _ ->
        gs
