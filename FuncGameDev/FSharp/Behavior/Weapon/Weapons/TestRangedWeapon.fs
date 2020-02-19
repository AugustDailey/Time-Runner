module TestRangedWeapon

// The Test Ranged Weapon is a weapon
// It performs a basic shooting attack

let attack (weaponData: WeaponData.T) (commonEntityData: CommonEntityData.T) xy degrees (gs: GameState.T) = 
    let rad = (float)degrees * System.Math.PI / 180.0;
    let x = 1.0 * (rad |> System.Math.Cos) + (xy |> fst);
    let y = 1.0 * (rad |> System.Math.Sin) + (xy |> snd);
    let newGS = RangedProjectile.spawn weaponData (x, y) 10.0 degrees gs |> GameStateUtils.modifyForSpawn;
    newGS;

let spawn xy bid (gs:GameState.T) =
    let weaponData = {
        CommonEntityData.id = gs.nextid;
        CommonEntityData.position = xy;
        CommonEntityData.speed = 0.0;
        CommonEntityData.direction = 0.0;
        CommonEntityData.isMoving = false;
        CommonEntityData.data = EntityType.Weapon {
            WeaponData.weaponName = "Ranged Weapon";
            WeaponData.cooldown = 0.4;
            WeaponData.damage = 35;
            WeaponData.effects = [];
            WeaponData.weaponType = WeaponData.Category.Ranged;
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
