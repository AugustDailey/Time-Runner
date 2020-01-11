module Spawner

open UnityEngine

let spawnEntity (gs:GameState.T) eid =
    let entity = GameStateUtils.getEntityByID gs eid
    let entityName = 
        match entity.data with
        | EntityType.Player player -> "Player"
        | EntityType.Enemy enemy -> "Enemy"
        | EntityType.Item item -> "Item"
        | EntityType.Weapon weapon -> "Weapon"
        | EntityType.Projectile projectile -> "Projectile"
    let go = entityName |> Resources.Load<GameObject> |> GameObject.Instantiate<GameObject>
    go.transform.position <- new Vector3(entity.position |> fst |> float32, entity.position |> snd |> float32)
    { GameObjectWrapper.id = eid; GameObjectWrapper.go = go}


let spawnGameObjects (gs:GameState.T) =
    let gameObjects = gs.spawnIds |> (gs |> spawnEntity |> List.map) // call spawnEntity with given gamestate on all ids in spawnIds
    GameState.instance <- { gs with spawnIds = List.empty }
    gameObjects

