module ItemBehavior

//activate the item's on-pickup effect
//iid: int = id of the item
//eid: int = id of the entity that picked it up
//gs: GameState = the current gamestate
//returns a function that takes a gamestate and returns a gamestate
let onpickup iid eid gs =
    gs;

//activate the item's on-destroy effect
//iid: int = id of the item
//eid: int = id of the entity that picked it up
//gs: GameState = the current gamestate
//returns a function that takes a gamestate and returns a gamestate
let ondestroy iid eid gs =
    gs;