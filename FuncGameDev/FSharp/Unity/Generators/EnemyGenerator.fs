module EnemyGenerator

open UnityEngine


let lowerXBound = -10
let upperXBound = 10
let lowerYBound = -5
let upperYBound = 5

let r = new System.Random()

let validatePosition (x : float) (y : float) entities = 
    true

let createEntity enemyNumber =
    
    //let mutable invalidPos = true
    //let mutable xPos = 0.0
    //let mutable yPos = 0.0
    //while invalidPos do
    //    let r = new System.Random()
    //    let xRand = r.NextDouble()
    //    let yRand = r.NextDouble()
    //    xPos = (xRand - 0.5) * 20.0
    //    yPos = (yRand - 0.5) * 10.0

    //    validatePosition xPos yPos entities
    //    invalidPos = false
    
    let xRand = r.NextDouble()
    let yRand = r.NextDouble()
    let xPos = (xRand - 0.5) * CameraInterpreter.GetCameraWidth
    let yPos = (yRand - 0.5) * CameraInterpreter.GetCameraHeight

    Spawner.spawnEnemy (xPos, yPos) 2

    ()
    

let generateEntities (numEnemies : int) = 
    [1..numEnemies] |> List.iter createEntity







