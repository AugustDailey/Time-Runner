module TestRollWeapon

// The Test Roll Weapon is a roll move
// It moves the user 5 units in the direction they are facing

let attack (weaponData: WeaponData.T) (commonEntityData: CommonEntityData.T) xy degrees (gs: GameState.T) = 
    //let newGS = CommonEntityBehavior.move commonEntityData.id (5.0, 5.0) gs
    gs

let createWeapon () =
    {
        WeaponData.weaponName = "Melee Weapon";
        WeaponData.cooldown = 0.0;
        WeaponData.firerate = 1.0;
        WeaponData.damage = 0;
        WeaponData.effects = [];
        WeaponData.weaponType = WeaponData.Category.Roll;
        WeaponData.behaviorID = 2
    };

let spawn xy (gs:GameState.T) =
    let weaponData = {
        CommonEntityData.id = gs.nextid;
        CommonEntityData.position = xy;
        CommonEntityData.speed = 0.0;
        CommonEntityData.direction = 0.0;
        CommonEntityData.isMoving = false;
        CommonEntityData.data = createWeapon () |> EntityType.Weapon
        CommonEntityData.iframes = 0.0;
        CommonEntityData.sprite = "yay"
    }
    { gs with entities = Map.add gs.nextid weaponData gs.entities}

let behavior = {
    WeaponBehaviorType.attack = attack;
    WeaponBehaviorType.spawn = spawn;
    WeaponBehaviorType.createWeapon = createWeapon
}
