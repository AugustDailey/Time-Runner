module TestGenerator


let generateLayout (gs:GameState.T) =
    let endPos = match gs.level.stairpos with
    | (-7, -3) ->
        (6, 2)
    | _ ->
        (-7, -3)
    let grid = [|
        [| 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1|] ;
        [| 1 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 1|] ;
        [| 1 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 1|] ;
        [| 1 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 1|] ;
        [| 1 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 1|] ;
        [| 1 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 1|] ;
        [| 1 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 1|] ;
        [| 1 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 1|] ;
        [| 1 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 1|] ;
        [| 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1|] |]
    //let tileGrid = grid |> GeneratorUtils.convertIdsToTiles
    let levelData = {
        LevelData.grid = null;
        LevelData.size = (gs.gamedata.camera.width |> int, gs.gamedata.camera.height |> int);
        LevelData.startpos = gs.level.stairpos;
        LevelData.stairpos = endPos;
        LevelData.complete = false;
        LevelData.generator = 1
    }
    { gs with level = levelData}


let placePlayerAndStairs (gs:GameState.T) =
    let width = gs.level.size |> fst
    let height = gs.level.size |> snd
    gs.level.grid.[gs.level.startpos |> fst - width / 2].[gs.level.startpos |> snd - height / 2] <- -2
    gs
    
let placeEnemies (gs:GameState.T) =
    gs
        
        
let placeItems (gs:GameState.T) =
    gs


let behavior = {
    GeneratorBehaviorType.generateLayout = generateLayout
    GeneratorBehaviorType.placePlayerAndStairs = placePlayerAndStairs
    GeneratorBehaviorType.placeEnemies = placeEnemies
    GeneratorBehaviorType.placeItems = placeItems
}