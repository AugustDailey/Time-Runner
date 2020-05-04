module Tracker

let spawn xy bid (gs:GameState.T) =
    let enemyData = {
        CommonEntityData.id = gs.nextid;
        CommonEntityData.position = xy;
        CommonEntityData.speed = 4.0;
        CommonEntityData.direction = 0.0;
        CommonEntityData.isMoving = false;
        CommonEntityData.data = EntityType.Enemy {
            health = 60;
            weapon = {
                WeaponData.weaponName = "Temp Weapon";
                WeaponData.cooldown = 0.0;
                WeaponData.firerate = 0.4;
                WeaponData.damage = 35;
                WeaponData.effects = [];
                WeaponData.weaponType = WeaponData.Category.Melee;
                WeaponData.behaviorID = 0
            };
            effects = [];
            enemyType = "Tracker";
            behaviorId = bid;
            aiId = 2;
            isBoss = false
        };
        CommonEntityData.iframes = 0.0;
        CommonEntityData.sprite = "yay"
    }
    { gs with entities = Map.add gs.nextid enemyData gs.entities }

let behavior = {
    EnemyBehaviorType.spawn = spawn;
}
