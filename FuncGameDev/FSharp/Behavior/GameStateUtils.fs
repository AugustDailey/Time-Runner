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
    
//Removes the entity with the given ID
//and returns the resulting gamestate.
let removeEntityWithID (gs:GameState.T) eid =
    { gs with entities = Map.remove eid gs.entities }

//Marks an entity so we can destroy it
//at the end of the update loop,
//if and only if it is not already marked
let markEntityForDestruction (gs:GameState.T) eid =
    match (List.contains eid gs.killIds) with
    | true ->
        gs
    | false ->
        { gs with killIds = eid::gs.killIds }

//Removes all entities that have been marked for destruction
let removeMarkedEntities (gs:GameState.T) =
    List.fold removeEntityWithID gs gs.killIds

let modifyForSpawn (gs:GameState.T) =
    { gs with nextid = gs.nextid + 1 ; spawnIds = List.Cons (gs.nextid, gs.spawnIds) }
