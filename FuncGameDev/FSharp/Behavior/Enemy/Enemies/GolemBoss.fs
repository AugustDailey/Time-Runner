module GolemBoss

let spawn xy bid (gs:GameState.T) =
    let enemyData = {
        CommonEntityData.id = gs.nextid;
        CommonEntityData.position = xy;
        CommonEntityData.speed = 1.5;
        CommonEntityData.direction = 0.0;
        CommonEntityData.isMoving = false;
        CommonEntityData.data = EntityType.Enemy {
            health = 1500;
            weapon = GolemArm.createWeapon ()
            effects = [];
            enemyType = "GolemBoss";
            behaviorId = bid;
            aiId = 10;
            isBoss = true
        };
        CommonEntityData.iframes = 0.0;
        CommonEntityData.sprite = "yay"
    }
    { gs with entities = Map.add gs.nextid enemyData gs.entities ; level = { gs.level with stairsSpawned = false } }

let behavior = {
    EnemyBehaviorType.spawn = spawn;
}
