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
    let levelWidth = GameState.instance.level.size |> fst
    let levelHeight = GameState.instance.level.size |> snd
    let xRand = r.Next(levelWidth)
    let yRand = r.Next(levelHeight)
    let xPos = ((xRand - levelWidth / 2) |> float)
    let yPos = ((yRand - levelHeight / 2) |> float)
    Spawner.spawnEnemy (xPos, yPos) enemyID
    ()

let generateEntities enemies = 
    enemies |> List.iter createEntity







