module ItemBehaviorType

type T = {
    //Two functions which take the following:
    //  a CommonEntityData instance, which is the item in question
    //  a CommonEntityData instance, which is the owner of the item
    //  a GameState instance
    //They return a GameState instance
    //Also contains a spawn factory function that takes a position, the behavior id, and a GameState and returns a GameState
    onpickup: (CommonEntityData.T -> CommonEntityData.T -> GameState.T -> GameState.T)
    ondestroy: (CommonEntityData.T -> CommonEntityData.T -> GameState.T -> GameState.T)
    spawn: ((float * float) -> int -> GameState.T -> GameState.T)
}