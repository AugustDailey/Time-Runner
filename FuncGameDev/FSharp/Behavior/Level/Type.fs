module GeneratorBehaviorType

type T = {
    //They return a GameState instance
    generate: (GameState.T -> GameState.T)
}
