module EffectBehavior

//activate the effect's on-apply effect
//effid: int = id of the effect
//eid: int = id of the entity that it is being applied to
//gs: GameState = the current gamestate
//returns a function that takes a gamestate and returns a gamestate
let onapply effid eid gs =
    gs;

//activate the effect's on-tick effect
//effid: int = id of the effect
//eid: int = id of the entity that it is being applied to
//gs: GameState = the current gamestate
//returns a function that takes a gamestate and returns a gamestate
let ontick effid eid gs =
    gs;

//activate the effect's on-remove effect
//effid: int = id of the effect
//eid: int = id of the entity that it is being applied to
//gs: GameState = the current gamestate
//returns a function that takes a gamestate and returns a gamestate
let onremove effid eid gs =
    gs;