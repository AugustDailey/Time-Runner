module ItemBehaviorType

type T = {
    //Two functions which take the following:
    //  a CommonEntityData instance, which is the item in question
    //  a CommonEntityData instance, which is the owner of the item
    //  a GameState instance
    //They return a GameState instance
    onpickup: (CommonEntityData.T -> CommonEntityData.T -> GameState.T -> GameState.T)
    ondestroy: (CommonEntityData.T -> CommonEntityData.T -> GameState.T -> GameState.T)
}