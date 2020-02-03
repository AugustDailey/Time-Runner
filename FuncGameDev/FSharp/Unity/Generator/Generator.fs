module Generator

open UnityEngine

let createTile (tileEntity:TileData.T) =
    let tileName = match tileEntity.blockID with
    | 0 -> "None"
    | 1 -> "Enemy"
    match tileName with
    | "None" -> 
        null
    | _ -> 
        let tileObject = tileName |> Resources.Load<GameObject> |> GameObject.Instantiate<GameObject>
        tileObject.transform.position <- new Vector3(tileEntity.pos |> fst |> float32, tileEntity.pos |> snd |> float32)
        tileObject

let createTileFromRow tileRow =
    Array.map createTile tileRow

let generateLevel gs =
    let generatorBehavior = Map.find GameState.instance.level.generator GeneratorTable.Instance
    GameState.instance <- generatorBehavior.generate gs
    LevelGameObject.tiles = Array.map createTileFromRow GameState.instance.level.grid
    ()