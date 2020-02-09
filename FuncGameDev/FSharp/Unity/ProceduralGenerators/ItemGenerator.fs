module ItemGenerator

let r = new System.Random()

let createItem itemID = 
    let levelWidth = GameState.instance.level.size |> fst
    let levelHeight = GameState.instance.level.size |> snd
    let xRand = r.Next(levelWidth)
    let yRand = r.Next(levelHeight)
    let xPos = ((xRand - levelWidth / 2) |> float)
    let yPos = ((yRand - levelHeight / 2) |> float)
    Spawner.spawnItem (xPos, yPos) itemID
    ()

let generateItems items = 
    items |> List.iter createItem