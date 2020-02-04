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
    let xRand = r.Next(16) // TODO: replace with level width
    let yRand = r.Next(10) // TODO: replace with level height
    let xPos = ((xRand - xRand / 2) |> float)
    let yPos = ((yRand - yRand / 2) |> float)
    Spawner.spawnEnemy (xPos, yPos) enemyID
    ()

let generateEntities enemies = 
    enemies |> List.iter createEntity







