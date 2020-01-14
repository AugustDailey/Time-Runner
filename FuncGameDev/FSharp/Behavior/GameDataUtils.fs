module GameDataUtils

// Increases time and returns a new GameState with updated time
let increaseTime deltaTime (gs: GameState.T) =
    let gameData = gs.gamedata
    let newTime = gameData.time + deltaTime
    let newGameData = { gameData with time = newTime }
    { gs with gamedata = newGameData}

// Decreases time and returns a new GameState with updated time
let decreaseTime deltaTime (gs: GameState.T) =
    let gameData = gs.gamedata
    let newTime = gameData.time - deltaTime
    match newTime with
    | newTime when newTime < 0.0 ->
        let newGameData = { gameData with time = 0.0 }
        { gs with gamedata = newGameData }
    | _ ->
        let newGameData = { gameData with time = newTime }
        { gs with gamedata = newGameData }

    