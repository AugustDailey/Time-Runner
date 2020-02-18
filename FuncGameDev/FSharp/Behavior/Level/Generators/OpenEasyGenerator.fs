module OpenEasyGenerator

let insertRandomWall (gs:GameState.T) (grid:int list list) =
    let sizeY = List.length grid
    let sizeX = List.length grid.Head
    let x = sizeX |> gs.random.Next
    let y = sizeY |> gs.random.Next
    GeneratorUtils.insertBlockAtIndex x y 1 grid

let generate (gs:GameState.T) =
    let endPos = match gs.level.stairpos with
    | (-7, -3) ->
        (6, 2)
    | _ ->
        (-7, -3)
    let grid = [
        [ 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1] ;
        [ 1 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 1] ;
        [ 1 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 1] ;
        [ 1 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 1] ;
        [ 1 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 1] ;
        [ 1 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 1] ;
        [ 1 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 1] ;
        [ 1 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 1] ;
        [ 1 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 0 ; 1] ;
        [ 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1 ; 1] ]

    // insert random walls
    let wallCount = 30
    let gridWithWalls = List.fold (fun g func -> func g) grid ([0..wallCount] |> List.map (fun x -> insertRandomWall gs))

    GeneratorUtils.generateLevel gs gridWithWalls endPos


let behavior = {
    GeneratorBehaviorType.generate = generate
}