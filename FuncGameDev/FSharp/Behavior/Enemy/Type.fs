module EnemyBehaviorType

type T = {
    //One function which takes a behavior id and GameState and defines how the enemy is spawned
    //They return a GameState instance
    //Note that the AI function is stored in a different table over in the AI module
    spawn: ((float * float) -> int -> GameState.T -> GameState.T)
}