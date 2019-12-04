module ProjectileBehavior

//Spawn projectile
//effects: list of effects to put on projectile from the weapon
//speed: speed at which projectile should move
//angle: angle character was facing when firing projectile
//gs: GameState = the current gamestate
//returns a function that takes a gamestate and returns a gamestate
let spawnProjectile damage effects speed initX initY gs =
    let tempProjectile = {
        CommonEntityData.id = GameState.instance.nextid;
        CommonEntityData.position = (initX,initY);
        CommonEntityData.speed = speed;
        CommonEntityData.entity = EntityType.Projectile {
            damage = damage;
            effects = effects
        }
        CommonEntityData.sprite = "yay"
    }

    gs

//Somewhere we need to use UnityEngine to actually instantiate the projectile object

//Spawn projectile at the given position
//weaponData: WeaponData.T = weapon this projectile is spawned from
//xy: float*float = position to spawn projectile at
//speed: float = speed at which the projectile should travel
//direction: float = angle at which to tr
//gs: GameState = the current gamestate
//returns a function that takes a gamestate and returns a gamestate
let spawnProjectile (weaponData: WeaponData.T) xy speed degrees (gs: GameState.T) = 
    let id = gs.nextid
    gs.nextid = gs.nextid + 1
    let newProjectile = {
        CommonEntityData.id = id;
        CommonEntityData.position = xy;
        CommonEntityData.speed = speed;
        CommonEntityData.entity = EntityType.Projectile {
            damage = weaponData.damage; 
            effects = weaponData.effects;
            lifespan = 100.0;
            degrees = degrees;
        }
        CommonEntityData.sprite = "yay"
    }
    gs.entities.Add(id, newProjectile)


let collision pid eid (gs: GameState.T) =
    let projOption = gs.entities.TryFind(pid)
    match projOption with 
    | None -> gs
    | _ -> 
        gs