module ScoreSavingService

open System.IO

let getScore = 
    let baseDirectory = __SOURCE_DIRECTORY__
    let baseDirectory' = Directory.GetParent(baseDirectory)
    let filePath = "HighScore.txt"
    let fullPath = Path.Combine(baseDirectory'.FullName, filePath)
    let score =  File.ReadAllText(fullPath)
    score

let storeScore score =
    let baseDirectory = __SOURCE_DIRECTORY__
    let baseDirectory' = Directory.GetParent(baseDirectory)
    let filePath = "HighScore.txt"
    let fullPath = Path.Combine(baseDirectory'.FullName, filePath)
    File.WriteAllText(fullPath, score)
    ()