module Stander

let spawn xy bid (gs:GameState.T) =
    let enemyData = {
        CommonEntityData.id = gs.nextid;
        CommonEntityData.position = xy;
        CommonEntityData.speed = 5.0;
        CommonEntityData.data = EntityType.Enemy {
            health = 10;
            weapon = {
                WeaponData.weaponName = "Temp Weapon";
                WeaponData.cooldown = 0.4;
                WeaponData.damage = 35;
                WeaponData.effects = [];
                WeaponData.weaponType = WeaponData.Category.Melee;
                WeaponData.behaviorID = 0
            };
            effects = [];
            enemyType = "Enemy";
            behaviorId = bid;
            aiId = 1
        }
        CommonEntityData.sprite = "yay"
    }
    { gs with entities = Map.add gs.nextid enemyData gs.entities }

let behavior = {
    EnemyBehaviorType.spawn = spawn;
}
