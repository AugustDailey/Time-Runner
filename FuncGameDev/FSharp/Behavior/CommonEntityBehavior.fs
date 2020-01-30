module CommonEntityBehavior

open System

//Examples of common entities that would use these functions:
//players, enemies, items, projectiles
//Anything with a position uses these


//Move entity in direction indicated by degrees
//eid: int = id of entity
//degrees: float = angle to move, 0 is north, moves clockwise
//delta: float = the amount of time passed
//gs: GameState = the current gamestate
//returns a function that takes a gamestate and returns a gamestate
let move eid (degrees:float) (delta:float32) (gs : GameState.T) =
    let delta = float delta
    let entity = GameStateUtils.getEntityByID gs eid
    let radians = (degrees + 90.0) * Math.PI / -180.0
    let direction = (Math.Sin radians),(Math.Cos radians)
    let newEntity = { entity with isMoving = true; direction = direction}
    let newMap = gs.entities.Add(eid, newEntity)
    { gs with entities = newMap }

//Handle collision
//eid1: int = id of first colliding entity
//eid2: int = id of second colliding entity
//gs: GameState = the current gamestate
//returns a function that takes a gamestate and returns a gamestate
let collides eid1 eid2 gs =
    gs

//Remove the entity from existence
//eid: int = id of entity
//gs: GameState = the current gamestate
//returns a function that takes a gamestate and returns a gamestate
let die eid gs =
    gs

