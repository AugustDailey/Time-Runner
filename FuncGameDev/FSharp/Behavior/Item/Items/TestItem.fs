module TestItem

// The Test Item is an item
// When picked up, it increases the timer by 5 seconds
// When dropped, it decreases the time by 5 seconds

let onpickup (item:CommonEntityData.T) (owner:CommonEntityData.T) (gs:GameState.T) =
    { gs with gamedata = { gs.gamedata with time = gs.gamedata.time + 5.0 } }

let ondestroy (item:CommonEntityData.T) (owner:CommonEntityData.T) (gs:GameState.T) =
    { gs with gamedata = { gs.gamedata with time = gs.gamedata.time - 5.0 } }

let behavior = {
    ItemBehaviorType.onpickup = onpickup;
    ItemBehaviorType.ondestroy = ondestroy;
}
