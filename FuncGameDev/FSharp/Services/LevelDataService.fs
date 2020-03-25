module LevelDataService

open System.IO

let parseLevelParam (levelParamSplit:string[]) =
    let generator = levelParamSplit.[0] |> int
    let enemies = levelParamSplit.[1].Split([|','|]) |> Array.toList |> List.map System.Int32.Parse
    let items = levelParamSplit.[2].Split([|','|]) |> Array.toList |> List.map System.Int32.Parse
    (generator, enemies, items)
    
let splitLevelParam (levelParam:string) =
    levelParam.Split([|' '|]) |> parseLevelParam

let createLevelParam levelParamSplit =
    let generator,enemies,items = levelParamSplit
    { LevelParam.T.generator = generator; 
      LevelParam.T.enemies = enemies; 
      LevelParam.T.items = items }


let loadLevelParams (gs:GameState.T) = 
    let baseDirectory = __SOURCE_DIRECTORY__
    let baseDirectory' = Directory.GetParent(baseDirectory)
    let filePath = "Data Files/leveldata.txt"
    let fullPath = Path.Combine(baseDirectory'.FullName, filePath)
    let levelParamData =  File.ReadAllLines(fullPath)
    let levelParamDataSplit = levelParamData |> Array.map splitLevelParam
    let levelParams = levelParamDataSplit |> Array.map createLevelParam
    { gs with levelParams = levelParams }
