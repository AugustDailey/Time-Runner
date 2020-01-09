module Spawner

open UnityEngine

let spawnEntity (gs:GameState.T) eid =
    let entity = GameStateUtils.getEntityByID gs eid
    match entity.data with
    | EntityType.Player player ->
        let go = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Player"))
        go.transform.position = new Vector3(0.0f,0.0f)
        Debug.Log("Spawned GO")
        go
    | EntityType.Enemy enemy ->
        //spawn enemy
        let go = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Enemy"))
        go.transform.position = new Vector3(0.0f,0.0f)
        Debug.Log("Spawned GO")
        go
    | EntityType.Item item ->
        //spawn item
        let go = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Item"))
        go.transform.position = new Vector3(0.0f,0.0f)
        Debug.Log("Spawned GO")
        go
    | EntityType.Weapon weapon ->
        //spawn weapon
        let go = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Weapon"))
        go.transform.position = new Vector3(0.0f,0.0f)
        Debug.Log("Spawned GO")
        go
    | EntityType.Projectile projectile ->
        //spawn projectile
        let go = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Projectile"))
        go.transform.position = new Vector3(0.0f,0.0f)
        Debug.Log("Spawned GO")
        go

let update (gs:GameState.T) spawnIds =
    // create new gameobjects with ids matching those in the spawnIds list using data from the gamestate entity map
    GameState.instance = { gs with spawnIds = List.empty }
    ()
