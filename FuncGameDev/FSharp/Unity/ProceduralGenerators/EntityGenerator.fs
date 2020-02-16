module EntityGenerator

open UnityEngine

let createEntity (gs:GameState.T) spawnFunction entityID (validTiles:(int*int) list) =
    let pos = validTiles.Length |> gs.random.Next |> (List.nth validTiles)
    spawnFunction (pos |> fst |> float, pos |> snd |> float) entityID
    List.except [pos] validTiles

let generateEntities gs spawnFunction entities validTiles = 
    let createEntityFunList = entities |> List.map (createEntity gs spawnFunction)
    List.fold (fun validTiles func -> func validTiles) validTiles createEntityFunList







