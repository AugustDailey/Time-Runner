module TestGameState

let testMelee = {
    WeaponData.weaponName = "Test Melee Weapon";
    WeaponData.cooldown = 0.4;
    WeaponData.damage = 35;
    WeaponData.effects = [];
    WeaponData.weaponType = WeaponData.Category.Melee;
}

let testRanged = {
    WeaponData.weaponName = "Test Ranged Weapon";
    WeaponData.cooldown = 0.1;
    WeaponData.damage = 5;
    WeaponData.effects = [];
    WeaponData.weaponType = WeaponData.Category.Ranged;
}

let testRoll = {
    WeaponData.weaponName = "Test Roll Weapon";
    WeaponData.cooldown = 1.0;
    WeaponData.damage = 0;
    WeaponData.effects = [];
    WeaponData.weaponType = WeaponData.Category.Roll;
}

let testActive = {
    WeaponData.weaponName = "Test Active Weapon";
    WeaponData.cooldown = 10.0;
    WeaponData.damage = 125;
    WeaponData.effects = [];
    WeaponData.weaponType = WeaponData.Category.Active;
}

let testPlayer = {
    CommonEntityData.id = 1;
    CommonEntityData.position = (150.0,250.0);
    CommonEntityData.speed = 10;
    CommonEntityData.entity = EntityType.Player {
        melee = testMelee;
        ranged = testRanged;
        roll = testRoll;
        active = testActive;
        items = [];
        effects = []
    }
}

let testEnemy1 = {
    CommonEntityData.id = 2;
    CommonEntityData.position = (250.0,250.0);
    CommonEntityData.speed = 3;
    CommonEntityData.entity = EntityType.Enemy {
        health = 100;
        weapon = testMelee;
        effects = []
    }
}

let testEnemy2 = {
    CommonEntityData.id = 3;
    CommonEntityData.position = (150.0,150.0);
    CommonEntityData.speed = 4;
    CommonEntityData.entity = EntityType.Enemy {
        health = 100;
        weapon = testMelee;
        effects = []
    }
}

let testLevel = {
    LevelData.grid = Array2D.zeroCreate 20 20;
    LevelData.size = (20,20);
    LevelData.startpos = (5,5);
    LevelData.stairpos = (15,15)
}

let testGameData = {
    GameData.time = 60.0;
    GameData.floor = 0
}

let testGameState = {
    GameState.entities = Map.ofList[(1, testPlayer); (2, testEnemy1); (3, testEnemy2)];
    GameState.level = testLevel;
    GameState.gamedata = testGameData;
    GameState.nextid = 4
}
