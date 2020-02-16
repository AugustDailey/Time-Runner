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

let checkValidityOfTile validTiles (tile:TileData.T) =
    match tile.blockID with
    | 0 ->
        List.Cons ((tile.gridpos |> fst, tile.gridpos |> snd), validTiles)
    | _ ->
        validTiles

let checkValidityOfRow validTiles tileRow =
    Array.fold checkValidityOfTile validTiles tileRow

let areaNearPlayer startPos =
    let x = startPos |> fst
    let y = startPos |> snd
    [(x-2,y-2) ; (x-2,y-1) ; (x-2,y) ; (x-2,y+1) ; (x-2,y+2) ;
    (x-1,y-2) ; (x-1,y-1) ; (x-1,y) ; (x-1,y+1) ; (x-1,y+2) ;
    (x,y-2) ; (x,y-1) ; (x,y) ; (x,y+1) ; (x,y+2) ;
    (x+1,y-2) ; (x+1,y-1) ; (x+1,y) ; (x+1,y+1) ; (x+1,y+2) ;
    (x+2,y-2) ; (x+2,y-1) ; (x+2,y) ; (x+2,y+1) ; (x+2,y+2)]

let generateLevel (gs:GameState.T) (idGrid: int[][]) endPos =
    let tileGrid = idGrid |> convertIdsToTiles
    let startPos = gs.level.stairpos
    let size = (gs.gamedata.camera.width |> int, gs.gamedata.camera.height |> int)
    let validTiles = Array.fold checkValidityOfRow [] tileGrid
    let validTilesConverted = List.map (fun xy -> ((xy |> fst) - (size |> fst) / 2 + 1, (xy |> snd) - (size |> snd) / 2)) validTiles
    let posNearPlayer = startPos |> areaNearPlayer
    let validTilesWithoutPlayerPos = List.except posNearPlayer validTilesConverted
    let validTilesWithoutStairs = List.except [endPos] validTilesWithoutPlayerPos
    let levelData = {
        LevelData.grid = tileGrid;
        LevelData.validTiles = validTilesWithoutStairs;
        LevelData.size = size;
        LevelData.startpos = startPos;
        LevelData.stairpos = endPos;
        LevelData.complete = false;
        LevelData.generator = 1
    }
    { gs with level = levelData }