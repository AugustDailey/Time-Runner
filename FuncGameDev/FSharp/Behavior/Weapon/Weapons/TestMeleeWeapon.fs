module TestMeleeWeapon

// The Test Melee Weapon is a weapon
// It performs a basic slashing attack

let attack (weaponData: WeaponData.T) (commonEntityData: CommonEntityData.T) xy degrees (gs: GameState.T) = 
    let newGS = TestProjectile.spawn weaponData xy 0 degrees gs;
    newGS;

let spawn xy bid (gs:GameState.T) =
    let weaponData = {
        CommonEntityData.id = gs.nextid;
        CommonEntityData.position = xy;
        CommonEntityData.speed = 0.0;
        CommonEntityData.direction = 0.0;
        CommonEntityData.isMoving = false;
        CommonEntityData.data = EntityType.Weapon {
            WeaponData.weaponName = "Melee Weapon";
            WeaponData.cooldown = 0.4;
            WeaponData.damage = 35;
            WeaponData.effects = [];
            WeaponData.weaponType = WeaponData.Category.Melee;
            WeaponData.behaviorID = bid
        };
        CommonEntityData.iframes = 0.0;
        CommonEntityData.sprite = "yay"
    }
    { gs with entities = Map.add gs.nextid weaponData gs.entities}

let behavior = {
    WeaponBehaviorType.attack = attack;
    WeaponBehaviorType.spawn = spawn
}
