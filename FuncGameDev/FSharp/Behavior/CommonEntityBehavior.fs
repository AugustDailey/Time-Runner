module CommonEntityBehavior

open System

//Examples of common entities that would use these functions:
//players, enemies, items, projectiles
//Anything with a position uses these


//Set entity to move and let Unity handle the rest
//eid: int = id of entity
//degrees: float = direction to move in
//gs: GameState = the current gamestate
//returns a function that takes a gamestate and returns a gamestate
let move eid degrees (gs : GameState.T) =
    let entity = GameStateUtils.getEntityByID gs eid
    let newEntity = { entity with isMoving = true ; direction = degrees }
    { gs with entities = Map.add eid newEntity gs.entities }



