module GameDataUtils

// Increases time and returns a new GameState with updated time
let increaseTime deltaTime (gs: GameState.T) =
    let gameData = gs.gamedata
    let newTime = gameData.time + deltaTime
    let newGameData = { gameData with time = newTime }
    let newGS = { gs with gamedata = newGameData}
    newGS

// Decreases time and returns a new GameState with updated time
let decreaseTime deltaTime (gs: GameState.T) =
    let gameData = gs.gamedata
    let newTime = gameData.time - deltaTime
    if newTime < 0.0 then 
        let newGameData = { gameData with time = 0.0 }
        let newGS = { gs with gamedata = newGameData}
        newGS
    else 
        let newGameData = { gameData with time = newTime }
        let newGS = { gs with gamedata = newGameData}
        newGS

    