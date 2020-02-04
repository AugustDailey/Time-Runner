module EnemyGenerator

open UnityEngine


let lowerXBound = -10
let upperXBound = 10
let lowerYBound = -5
let upperYBound = 5

let createEnemyList (level : int) =
    let entitiesMap = 
        Map.empty
    entitiesMap

let validatePosition (x : float) (y : float) entities = 
    true

let assignPositions enemyNumber =
    let gs = GameState.instance
    let entities = gs.entities

    let mutable invalidPos = true
    let mutable xPos = 0.0
    let mutable yPos = 0.0
    while invalidPos do
        let r = new System.Random()
        let xRand = r.NextDouble()
        let yRand = r.NextDouble()
        xPos = (xRand - 0.5) * 20.0
        yPos = (yRand - 0.5) * 10.0

        validatePosition xPos yPos entities
    
    let tempWeapon = {
        WeaponData.weaponName = "Temp Weapon";
        WeaponData.cooldown = 0.4;
        WeaponData.damage = 35;
        WeaponData.effects = [];
        WeaponData.weaponType = WeaponData.Category.Melee;
        WeaponData.behaviorID = 0
    }

    let enemy1 = {
        CommonEntityData.id = GameState.instance.nextid;
        CommonEntityData.position = (xPos, yPos);
        CommonEntityData.speed = 5.0;
        CommonEntityData.data = EntityType.Enemy {
            health = 10;
            weapon = tempWeapon;
            effects = [];
            enemyType = "Tracker"
        }
        CommonEntityData.sprite = "yay"
    }
    
    GameState.instance.nextid = GameState.instance.nextid + 1

    let entitiesMap = 
        Map.empty.
            Add(enemy1.id, enemy1)
    let spawnIds = [enemy1.id]
    GameState.instance <- { gs with entities = entitiesMap; spawnIds = spawnIds }
    

    ()
    

let generateEntities (level : int) = 
    [1..3] |> List.iter assignPositions







