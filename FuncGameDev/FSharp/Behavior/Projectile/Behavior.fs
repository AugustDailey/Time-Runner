module ProjectileBehavior

//Spawn projectile at the given position
//weaponData: WeaponData.T = weapon this projectile is spawned from
//xy: float*float = position to spawn projectile at
//speed: float = speed at which the projectile should travel
//direction: float = angle at which to tr
//gs: GameState = the current gamestate
//returns a function that takes a gamestate and returns a gamestate
let spawn bid (weaponData: WeaponData.T) xy speed degrees (gs: GameState.T) = 
    let projBehavior = Map.find bid ProjectileBehaviorTable.Instance
    projBehavior.spawn weaponData xy speed degrees gs |> GameStateUtils.modifyForSpawn

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

let decreaseLifespan pid deltaTime (gs:GameState.T) =
    let projData = GameStateUtils.getEntityByID gs pid
    match projData.data with
    | EntityType.Projectile proj ->
        let newLifespan = proj.lifespan - deltaTime
        let newGs = match newLifespan <= 0.0 with
        | true ->
            GameStateUtils.markEntityForDestruction gs pid
        | false ->
            gs
        let newProj = { proj with lifespan = newLifespan}
        let newData = { projData with data = EntityType.Projectile newProj}
        { newGs with entities = Map.add pid newData gs.entities }

let collideWithPlayer (projData:CommonEntityData.T) (playerData:CommonEntityData.T) (gs: GameState.T) =
    match projData.data with
    | EntityType.Projectile proj ->
        match proj.team with
        | 0 ->
            gs
        | _ ->
            let newProj = { proj with health = proj.health - 1}
            let projDamage = proj.damage |> float
            let gsWithReducedTime = GameDataUtils.decreaseTime projDamage gs
            match newProj.health with
            | 0 ->
                let gsWithoutProj = GameStateUtils.markEntityForDestruction gsWithReducedTime projData.id
                { gsWithoutProj with entities = Map.add projData.id { projData with data = EntityType.Projectile newProj } gsWithoutProj.entities}
            | _ ->
                { gsWithReducedTime with entities = Map.add projData.id { projData with data = EntityType.Projectile newProj } gsWithReducedTime.entities}

let collideWithEnemy (projData:CommonEntityData.T) (enemyData:CommonEntityData.T) (gs: GameState.T) =
    match projData.data with
    | EntityType.Projectile proj ->
        match enemyData.data with
        | EntityType.Enemy enemy ->
            match proj.team with
            | 1 ->
                gs
            | _ ->
                let newProj = { proj with health = proj.health - 1}
                let newData = { enemy with health = enemy.health - proj.damage }
                let newEnemyData = { enemyData with data = EntityType.Enemy newData }
                let gsPostEnemy = match newData.health <= 0 with
                | true ->
                    let tempGS = GameStateUtils.markEntityForDestruction gs enemyData.id
                    let gsWithoutEnemy = { tempGS with entities = Map.add enemyData.id newEnemyData tempGS.entities }
                    match newData.isBoss with
                    | false ->
                        gsWithoutEnemy
                    | true ->
                        { gsWithoutEnemy with level = { gsWithoutEnemy.level with stairsSpawned = true } }
                | false ->
                    { gs with entities = Map.add enemyData.id newEnemyData gs.entities }
                match newProj.health with
                | 0 ->
                    let gsWithoutProj = GameStateUtils.markEntityForDestruction gsPostEnemy projData.id
                    { gsWithoutProj with entities = Map.add projData.id { projData with data = EntityType.Projectile newProj } gsWithoutProj.entities}
                | _ ->
                    { gsPostEnemy with entities = Map.add projData.id { projData with data = EntityType.Projectile newProj } gsPostEnemy.entities}

let collideWithWall (projData:CommonEntityData.T) (gs:GameState.T) =
    projData.id |> GameStateUtils.markEntityForDestruction gs
