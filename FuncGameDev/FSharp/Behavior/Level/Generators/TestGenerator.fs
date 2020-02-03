module TestGenerator


let generate (gs:GameState.T) =
    let size = (5, 5)
    let startPos = (2, 3)
    let endPos = (4, 3)
    let grid = [|
        [| 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1|] ;
        [| 1 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 1|] ;
        [| 1 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 1|] ;
        [| 1 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 1|] ;
        [| 1 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 1|] ;
        [| 1 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 1|] ;
        [| 1 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 1|] ;
        [| 1 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 1|] ;
        [| 1 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 1|] ;
        [| 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1|] |]
    let tileGrid = grid |> GeneratorUtils.convertIdsToTiles
    let levelData = {
        LevelData.grid = tileGrid;
        LevelData.size = size;
        LevelData.startpos = startPos;
        LevelData.stairpos = endPos;
        LevelData.generator = 1
    }
    { gs with level = levelData}


let behavior = {
    GeneratorBehaviorType.generate = generate
}