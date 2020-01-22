﻿module TestRollWeapon

// The Test Roll Weapon is a roll move
// It moves the user 5 units in the direction they are facing

let attack (weaponData: WeaponData.T) (commonEntityData: CommonEntityData.T) xy degrees (gs: GameState.T) = 
    let newGS = CommonEntityBehavior.moveBy commonEntityData.id (5.0, 5.0) gs
    newGS;

let behavior = {
    WeaponBehaviorType.attack = attack;
}