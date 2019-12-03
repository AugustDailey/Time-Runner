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
    }

    gs