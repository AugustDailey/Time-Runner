module GameStateUtils

//Command that does nothing,
//usually used to help handle empty cases.
let emptyCommand gs =
    gs

//Returns the entity of the given type
//associated with the given ID.
//Assumes that the given ID is valid.
//If it may not be, you should check it in the calling code.
let getEntityByID (gs:GameState.T) eid =
    let entity = Map.find eid gs.entities
    entity


