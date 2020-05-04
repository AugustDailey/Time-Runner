module TestRangedWeapon

// The Test Ranged Weapon is a weapon
// It performs a basic shooting attack

let attack (weaponData: WeaponData.T) (commonEntityData: CommonEntityData.T) xy degrees (gs: GameState.T) = 
    let rad = (float)degrees * System.Math.PI / 180.0;
    let x = 1.0 * (rad |> System.Math.Cos) + (xy |> fst);
    let y = 1.0 * (rad |> System.Math.Sin) + (xy |> snd);
    let newGS = ProjectileBehavior.spawn 1 weaponData (x, y) 10.0 degrees gs
    newGS;

let createWeapon () =
    {
        WeaponData.weaponName = "Ranged Weapon";
        WeaponData.cooldown = 0.0;
        WeaponData.firerate = 0.4;
        WeaponData.damage = 30;
        WeaponData.effects = [];
        WeaponData.weaponType = WeaponData.Category.Ranged;
        WeaponData.behaviorID = 3
    };

let spawn xy (gs:GameState.T) =
    let weaponData = {
        CommonEntityData.id = gs.nextid;
        CommonEntityData.position = xy;
        CommonEntityData.speed = 0.0;
        CommonEntityData.direction = 0.0;
        CommonEntityData.isMoving = false;
        CommonEntityData.data = createWeapon () |> EntityType.Weapon;
        CommonEntityData.iframes = 0.0;
        CommonEntityData.sprite = "yay"
    }
    { gs with entities = Map.add gs.nextid weaponData gs.entities}

let behavior = {
    WeaponBehaviorType.attack = attack;
    WeaponBehaviorType.spawn = spawn
    WeaponBehaviorType.createWeapon = createWeapon
}
