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
    UnityEngine.Debug.Log("wow")
    let delta = float delta
    let entityOption = gs.entities.TryFind(eid)
    let radians = degrees * Math.PI / 180.0
    match entityOption with
    | None -> gs
    | _ -> 
        let entity = entityOption.Value
        let position = entity.position
        let distance = (float) entity.speed * delta;
        let newPosition = ((fst position + distance * (Math.Sin radians)), (snd position + distance * (Math.Cos radians)))
        let newEntity = { entity with position = newPosition }
        let newMap = gs.entities.Add(eid, newEntity)
        { gs with entities = newMap }

//Move entity a set amount in each direction
//eid: int = id of entity (1-4)
//xy: float*float = amount to move in x and y directions
//gs: GameState = the current gamestate
//returns a function that takes a gamestate and returns a gamestate
let moveBy eid xy (gs: GameState.T) =
    let entityOption = gs.entities.TryFind(eid)
    match entityOption with
    | None -> gs
    | _ -> 
        let entity = entityOption.Value
        let position = entity.position
        let newPosition = ((fst position + fst xy), (snd position + snd xy))
        let newEntity = { entity with position = newPosition }
        let newMap = gs.entities.Add(eid, newEntity)
        { gs with entities = newMap }
    
//Move entity to an absolute position
//eid: int = id of entity
//xy: float*float = position to move to
//gs: GameState = the current gamestate
//returns a function that takes a gamestate and returns a gamestate
let moveTo eid xy (gs: GameState.T) = 
    let entityOption = gs.entities.TryFind(eid)
    match entityOption with
    | None -> gs
    | _ -> 
        let entity = entityOption.Value
        let newEntity = { entity with position = xy }
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

