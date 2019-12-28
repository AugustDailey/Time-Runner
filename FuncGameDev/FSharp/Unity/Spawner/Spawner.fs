module Spawner

open UnityEngine

let spawnEntity (gs:GameState.T) eid =
    let entity = GameStateUtils.getEntityByID gs eid
    match entity.data with
    | EntityType.Player player ->
        //spawn player
        gs
    | EntityType.Enemy enemy ->
        //spawn enemy
        gs
    | EntityType.Item item ->
        //spawn item
        gs
    | EntityType.Weapon weapon ->
        //spawn weapon
        gs
    | EntityType.Projectile projectile ->
        //spawn projectile
        gs

let update (gs:GameState.T) spawnIds =
    // create new gameobjects with ids matching those in the spawnIds list using data from the gamestate entity map
    GameState.instance = { gs with spawnIds = List.empty }
    ()

