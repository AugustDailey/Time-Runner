module GeneratorBehaviorType

type T = {
    //They return a GameState instance
    generateLayout: (GameState.T -> GameState.T)
    placePlayerAndStairs: (GameState.T -> GameState.T)
    placeEnemies: (GameState.T -> GameState.T)
    placeItems: (GameState.T -> GameState.T)
}
