module ProjectileBehavior

//Spawn projectile at the given position
//weaponData: WeaponData.T = weapon this projectile is spawned from
//xy: float*float = position to spawn projectile at
//speed: float = speed at which the projectile should travel
//direction: float = angle at which to tr
//gs: GameState = the current gamestate
//returns a function that takes a gamestate and returns a gamestate
let spawn (weaponData: WeaponData.T) xy speed degrees (gs: GameState.T) = 
    let id = gs.nextid
    gs.nextid = gs.nextid + 1
    let newProjectile = {
        CommonEntityData.id = id
        CommonEntityData.position = xy
        CommonEntityData.speed = speed
        CommonEntityData.data = EntityType.Projectile {
            damage = weaponData.damage
            effects = weaponData.effects
            lifespan = 100.0
            degrees = degrees
            behaviorID = 1
            health = 1
            team = 0
        }
        CommonEntityData.sprite = "yay"
    }
    {gs with entities = gs.entities.Add(id, newProjectile)}

let move pid (deltaTime: float32) (gs: GameState.T) =
    let projData = GameStateUtils.getEntityByID gs pid
    let delta = float deltaTime
    match projData.data with
    | EntityType.Projectile proj ->
        let projBehavior = Map.find proj.behaviorID ProjectileBehaviorTable.Instance
        projBehavior.move projData delta gs
    | _ ->
        gs

let collision pid eid (gs: GameState.T) =
    let projData = GameStateUtils.getEntityByID gs pid
    match projData.data with
    | EntityType.Projectile proj ->
        let entityData = GameStateUtils.getEntityByID gs eid
        let projBehavior = Map.find proj.behaviorID ProjectileBehaviorTable.Instance
        projBehavior.collision projData entityData gs
    | _ ->
        gs