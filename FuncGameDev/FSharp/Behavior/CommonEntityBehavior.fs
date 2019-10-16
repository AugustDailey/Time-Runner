module CommonEntityBehavior
//Examples of common entities that would use these functions:
//players, enemies, items, projectiles
//Anything with a position uses these


//Move entity in direction indicated by degrees
//eid: int = id of entity
//degrees: float = angle to move, 0 is north, moves clockwise
//gs: GameState = the current gamestate
//returns a function that takes a gamestate and returns a gamestate
let move eid degrees (gs : obj) =
    gs

//Move entity a set amount in each direction
//eid: int = id of entity (1-4)
//xy: float*float = amount to move in x and y directions
//gs: GameState = the current gamestate
//returns a function that takes a gamestate and returns a gamestate
let moveBy eid xy gs =
    gs
    
//Move entity to an absolute position
//eid: int = id of entity
//xy: float*float = position to move to
//gs: GameState = the current gamestate
//returns a function that takes a gamestate and returns a gamestate
let moveTo eid xy gs = 
    gs

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