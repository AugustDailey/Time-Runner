module TestMeleeWeapon

// The Test Melee Weapon is a weapon
// It performs a basic slashing attack

let attack (weaponData: WeaponData.T) (commonEntityData: CommonEntityData.T) xy degrees (gs: GameState.T) = 
    let newGS = TestProjectile.spawn weaponData xy 0 degrees gs;
    newGS;

let behavior = {
    WeaponBehaviorType.attack = attack;
}
