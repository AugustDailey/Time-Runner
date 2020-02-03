module GeneratorUtils

let spawnTile xy blockID =
    { // just creates a tile with given position and id
        TileData.blockID = blockID;
        TileData.gridpos = xy
        TileData.pos = ((xy |> fst |> float) - 5.0, (xy |> snd |> float) - 4.0)
    }

let spawnTileRow sizeRow idRow =
    Array.map2 spawnTile sizeRow idRow

let convertIdsToTiles (idGrid: int[][]) =
    let size = Array.length idGrid
    let sizeGrid = Array.init size (fun x -> Array.init size (fun y -> (x, y)))
    let tileGrid = Array.map2 spawnTileRow sizeGrid idGrid
    tileGrid