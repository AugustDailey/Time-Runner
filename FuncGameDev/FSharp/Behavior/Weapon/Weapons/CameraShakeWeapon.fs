module CameraShakeWeapon

// Active weapon that shakes the camera

let attack (weaponData: WeaponData.T) (commonEntityData: CommonEntityData.T) xy degrees (gs: GameState.T) = 
    { gs with gamedata = { gs.gamedata with camera = { gs.gamedata.camera with shakeTime = 0.2 } } }

let createWeapon () =
    {
        WeaponData.weaponName = "Camera Shake";
        WeaponData.cooldown = 0.0;
        WeaponData.firerate = 0.1;
        WeaponData.damage = 0;
        WeaponData.effects = [];
        WeaponData.weaponType = WeaponData.Category.Active;
        WeaponData.behaviorID = 4
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
