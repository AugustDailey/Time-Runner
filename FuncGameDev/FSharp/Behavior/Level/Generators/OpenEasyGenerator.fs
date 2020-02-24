module OpenEasyGenerator

let insertRandomWall (gs:GameState.T) (grid:int list list) =
    let sizeY = List.length grid
    let sizeX = List.length grid.Head
    let x = sizeX |> gs.random.Next
    let y = sizeY |> gs.random.Next
    GeneratorUtils.insertBlockAtIndex x y 1 grid

let generate (gs:GameState.T) =
    let endPos = match gs.level.stairpos with
    | (-14, -7) ->
        (13, 5)
    | _ ->
        (-14, -7)
    let grid = TestGenerator.createIDGrid gs

    // insert random walls
    let wallCount = 75
    let gridWithWalls = List.fold (fun g func -> func g) grid ([0..wallCount] |> List.map (fun x -> insertRandomWall gs))

    GeneratorUtils.generateLevel gs gridWithWalls endPos


let behavior = {
    GeneratorBehaviorType.generate = generate
}