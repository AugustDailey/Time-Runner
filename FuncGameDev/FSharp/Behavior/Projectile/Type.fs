module ProjectileBehaviorType

type T = {
    
    //They return a GameState instance
    spawn: (WeaponData.T -> float*float -> float -> float -> GameState.T -> GameState.T)
    move: (CommonEntityData.T -> float -> GameState.T -> GameState.T)
    collision: (CommonEntityData.T -> CommonEntityData.T -> GameState.T -> GameState.T)
}