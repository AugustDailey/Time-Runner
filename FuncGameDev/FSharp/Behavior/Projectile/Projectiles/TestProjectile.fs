module TestProjectile

// The Test Item is an item
// When picked up, it increases the timer by 5 seconds
// When dropped, it decreases the time by 5 seconds

let spawn (weaponData: WeaponData.T) xy speed degrees (gs: GameState.T) =
    gs

let move (projData: CommonEntityData.T) (deltaTime: float) (gs: GameState.T) =
    match projData.entity with 
    | EntityType.Projectile proj ->
        let newX = projData.speed * cos proj.degrees * deltaTime + fst projData.position
        let newY = projData.speed * sin proj.degrees * deltaTime + snd projData.position
        let newPos = (newX, newY)
        {gs with entities = gs.entities.Add(projData.id, {projData with CommonEntityData.position = newPos})}
    | _ ->
        gs
        
let collision pid eid (gs: GameState.T) =
    gs

let behavior = {
    ProjectileBehaviorType.spawn = spawn;
    ProjectileBehaviorType.move = move;
    ProjectileBehaviorType.collision = collision
}
