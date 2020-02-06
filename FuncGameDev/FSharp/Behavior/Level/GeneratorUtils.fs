module GeneratorUtils

let spawnTile size xy blockID =
    { // just creates a tile with given position and id
        TileData.blockID = blockID;
        TileData.gridpos = xy
        TileData.pos = ((xy |> fst |> float) - (size |> fst) / 2.0, (xy |> snd |> float) - (size |> snd) / 2.0)
    }

let spawnTileRow size posRow idRow =
    Array.map2 (spawnTile size) posRow idRow

let convertIdsToTiles (idGrid: int[][]) =
    let sizeX = Array.length idGrid.[0]
    let sizeY = Array.length idGrid
    let posGrid = Array.init sizeY (fun y -> Array.init sizeX (fun x -> (x, y)))
    let tileGrid = Array.map2 (spawnTileRow (sizeX |> float, sizeY |> float)) posGrid idGrid
    tileGrid