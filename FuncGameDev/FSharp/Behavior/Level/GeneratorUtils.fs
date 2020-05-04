module GeneratorUtils

let spawnTile size xy blockID =
    { // just creates a tile with given position and id
        TileData.blockID = blockID;
        TileData.gridpos = xy
        TileData.pos = ((xy |> fst |> float) - (size |> fst) / 2.0, (xy |> snd |> float) - (size |> snd) / 2.0)
    }

let spawnTileRow size posRow idRow =
    List.map2 (spawnTile size) posRow idRow

let convertIdsToTiles (idGrid: int list list) =
    let sizeX = List.length idGrid.[0]
    let sizeY = List.length idGrid
    let posGrid = List.init sizeY (fun y -> List.init sizeX (fun x -> (x, y)))
    let tileGrid = List.map2 (spawnTileRow (sizeX |> float, sizeY |> float)) posGrid idGrid
    tileGrid

let checkValidityOfTile validTiles (tile:TileData.T) =
    match tile.blockID with
    | 0 ->
        List.Cons ((tile.gridpos |> fst, tile.gridpos |> snd), validTiles)
    | _ ->
        validTiles

let checkValidityOfRow validTiles tileRow =
    List.fold checkValidityOfTile validTiles tileRow

let areaNearPlayer startPos =
    let x = startPos |> fst
    let y = startPos |> snd
    [(x-2,y-2) ; (x-2,y-1) ; (x-2,y) ; (x-2,y+1) ; (x-2,y+2) ;
    (x-1,y-2) ; (x-1,y-1) ; (x-1,y) ; (x-1,y+1) ; (x-1,y+2) ;
    (x,y-2) ; (x,y-1) ; (x,y) ; (x,y+1) ; (x,y+2) ;
    (x+1,y-2) ; (x+1,y-1) ; (x+1,y) ; (x+1,y+1) ; (x+1,y+2) ;
    (x+2,y-2) ; (x+2,y-1) ; (x+2,y) ; (x+2,y+1) ; (x+2,y+2)]

let insertBlockAtIndex x y blockID (grid: int list list) =
    List.mapi (fun yi col ->
        List.mapi (fun xi ele ->
            match (xi,yi) = (x,y) with
            | true -> blockID
            | false -> ele) 
            col)
        grid

let generateLevel (gs:GameState.T) (idGrid: int list list) endPos =
    let startPos = gs.level.stairpos
    let size = (gs.gamedata.camera.width |> int, gs.gamedata.camera.height |> int)
    let sizeX, sizeY = size
    
    let startX = ((startPos |> fst) + sizeX / 2 - 1)
    let startY = ((startPos |> snd) + sizeY / 2)
    let endX = ((endPos |> fst) + sizeX / 2)
    let endY = ((endPos |> snd) + sizeY / 2)

    // make start and stair positions floor
    let idGridFixed = idGrid |> 
        (insertBlockAtIndex startX startY 0) |> 
        (insertBlockAtIndex endX endY 0)

    // convert block numbers to actual tiles
    let tileGrid = idGridFixed |> convertIdsToTiles

    // generate the list of valid entity spawning positions
    let validTiles = List.fold checkValidityOfRow [] tileGrid
    let validTilesConverted = List.map (fun xy -> ((xy |> fst) - sizeX / 2, (xy |> snd) - sizeY / 2)) validTiles
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
        LevelData.generator = 1;
        LevelData.stairsSpawned = true
    }

    { gs with level = levelData }
