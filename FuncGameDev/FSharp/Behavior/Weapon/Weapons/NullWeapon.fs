module NullWeapon

// The Null Melee Weapon is a weapon
// It does nothing, it is the weapon the player holds when they do not have a weapon in give slot

let attack (weaponData: WeaponData.T) (commonEntityData: CommonEntityData.T) xy degrees (gs: GameState.T) = 
    gs

let createWeapon () =
    {
        WeaponData.weaponName = "Null Weapon";
        WeaponData.cooldown = 0.0;
        WeaponData.firerate = 0.5;
        WeaponData.damage = 0;
        WeaponData.effects = [];
        WeaponData.weaponType = WeaponData.Category.Active;
        WeaponData.behaviorID = 0
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
    WeaponBehaviorType.spawn = spawn
    WeaponBehaviorType.createWeapon = createWeapon
}