module RangedProjectile

// Projectile for ranged attacks

let spawn (weaponData: WeaponData.T) xy speed degrees (gs: GameState.T) =
    let projectileData = {
        CommonEntityData.id = gs.nextid;
        CommonEntityData.position = xy;
        CommonEntityData.speed = speed;
        CommonEntityData.direction = degrees;
        CommonEntityData.isMoving = true;
        CommonEntityData.data = EntityType.Projectile {
            ProjectileData.damage = weaponData.damage; 
            ProjectileData.effects = weaponData.effects;
            ProjectileData.lifespan = 1.0;
            ProjectileData.degrees = degrees; 
            ProjectileData.behaviorID = 0;
            ProjectileData.health = 1;
            ProjectileData.team = 0
        }
        CommonEntityData.iframes = 0.0;
        CommonEntityData.sprite = "Knife"
    }
    { gs with entities = Map.add gs.nextid projectileData gs.entities}

let move (projData: CommonEntityData.T) (deltaTime: float) (gs: GameState.T) =
    match projData.data with 
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
