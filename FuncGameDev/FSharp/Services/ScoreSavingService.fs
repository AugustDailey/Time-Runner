module ScoreSavingService

open System.IO

// Scores is an array of Strings. 
// Scores [0] represents the floor reached
// Scores [1] represents the time remaining
// Scores [2] represents the total time spent
let getScores = 
    let baseDirectory = __SOURCE_DIRECTORY__
    let baseDirectory' = Directory.GetParent(baseDirectory)
    let filePath = "HighScore.txt"
    let fullPath = Path.Combine(baseDirectory'.FullName, filePath)
    let scores =  File.ReadAllLines(fullPath)
    scores

let storeScores scores =
    let baseDirectory = __SOURCE_DIRECTORY__
    let baseDirectory' = Directory.GetParent(baseDirectory)
    let filePath = "HighScore.txt"
    let fullPath = Path.Combine(baseDirectory'.FullName, filePath)
    File.WriteAllLines(fullPath, scores)
    ()