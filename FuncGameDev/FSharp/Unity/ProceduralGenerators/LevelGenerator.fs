module Generator

open UnityEngine

let createTile (tileEntity:TileData.T) =
    let tileName = match tileEntity.blockID with
    | 0 -> "None"
    | 1 -> "Wall"
    match tileName with
    | "None" -> 
        null
    | _ -> 
        let tileObject = tileName |> Resources.Load<GameObject> |> GameObject.Instantiate<GameObject>
        tileObject.transform.position <- new Vector3(tileEntity.pos |> fst |> float32, tileEntity.pos |> snd |> float32)
        tileObject

let createTileFromRow tileRow =
    List.map createTile tileRow

let destroyTile (tile:GameObject) =
    tile |> UnityEngine.Object.Destroy
    ()

let destroyTileRow tileRow =
    List.iter destroyTile tileRow

let generateLevel gs =
    // generate level in the gamestate
    //let newGs = GeneratorBehavior.generate gs 2
    let newGs = GeneratorBehavior.generate gs 1
    GameState.instance <- newGs

    // create wall game objects
    List.iter destroyTileRow LevelGameObject.tiles
    LevelGameObject.tiles <- List.map createTileFromRow GameState.instance.level.grid

    // create or update stairs game object
    let go = match LevelGameObject.stairs with
    | null -> 
        "Stairs" |> Resources.Load<GameObject> |> GameObject.Instantiate<GameObject>
    | _ ->
        LevelGameObject.stairs
    go.transform.position <- new Vector3(newGs.level.stairpos |> fst |> float32, newGs.level.stairpos |> snd |> float32)
    LevelGameObject.stairs <- go


    // teleport all players to the new level's start position
    Map.iter (fun id (wrapper:GameObjectWrapper.T) -> wrapper.go.transform.position <- new Vector3(newGs.level.startpos |> fst |> float32, newGs.level.startpos |> snd |> float32)) GameObjectWrapper.wrappers

    // generate items, enemies, etc.
    //let generateEnemies = EntityGenerator.generateEntities newGs Spawner.spawnEnemy [3 ; 3 ; 2 ; 2 ; 2 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1]
    //let generateItems = EntityGenerator.generateEntities newGs Spawner.spawnItem [1 ; 1 ; 1 ; 1 ; 1]
    let generateEnemies = EntityGenerator.generateEntities newGs Spawner.spawnEnemy [10]
    let generateItems = EntityGenerator.generateEntities newGs Spawner.spawnItem []
    newGs.level.validTiles |> generateEnemies |> generateItems
    ()

let tryGenerateLevel (gs:GameState.T) =
    match gs.level.complete with
    | true ->
        generateLevel gs
    | false ->
        ()