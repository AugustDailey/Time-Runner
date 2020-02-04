module EnemyGenerator

open UnityEngine


let lowerXBound = -10
let upperXBound = 10
let lowerYBound = -5
let upperYBound = 5

let r = new System.Random()

let validatePosition (x : float) (y : float) entities = 
    true

let createEntity enemyID =
    let xRand = CameraInterpreter.GetCameraWidth |> int |> r.Next
    let yRand = CameraInterpreter.GetCameraHeight |> int |> r.Next
    let xPos = ((xRand - xRand / 2) |> float)
    let yPos = ((yRand - yRand / 2) |> float)
    Spawner.spawnEnemy (xPos, yPos) enemyID
    ()

let generateEntities enemies = 
    enemies |> List.iter createEntity







