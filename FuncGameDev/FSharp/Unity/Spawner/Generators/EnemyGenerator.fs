module EnemyGenerator

open UnityEngine


let lowerXBound = -10
let upperXBound = 10
let lowerYBound = -5
let upperYBound = 5

let r = new System.Random()

let createEnemyList (level : int) =
    let entitiesMap = 
        Map.empty
    entitiesMap

let validatePosition (x : float) (y : float) entities = 
    true

let join (p:Map<'a,'b>) (q:Map<'a,'b>) = 
    Map(Seq.concat [ (Map.toSeq p) ; (Map.toSeq q) ])

let merge a b =
    a @ b
    |> Seq.distinct
    |> List.ofSeq

let assignPositions enemyNumber =
    let gs = GameState.instance
    let entities = gs.entities

    let mutable invalidPos = true
    //let mutable xPos = 0.0
    //let mutable yPos = 0.0
    //while invalidPos do
    //    let r = new System.Random()
    //    let xRand = r.NextDouble()
    //    let yRand = r.NextDouble()
    //    xPos = (xRand - 0.5) * 20.0
    //    yPos = (yRand - 0.5) * 10.0

    //    validatePosition xPos yPos entities
    //    invalidPos = false
    
    let xRand = r.NextDouble()
    let yRand = r.NextDouble()
    let xPos = (xRand - 0.5) * 20.0
    let yPos = (yRand - 0.5) * 10.0
    Debug.Log("Xpos = " + string(xPos))
    //Debug.Log("Incorrect Xpos = " + string(xPos))
    Debug.Log("YPos = " + string(yPos))
    let id = GameState.instance.nextid + 1

    let tempWeapon = {
        WeaponData.weaponName = "Temp Weapon";
        WeaponData.cooldown = 0.4;
        WeaponData.damage = 35;
        WeaponData.effects = [];
        WeaponData.weaponType = WeaponData.Category.Melee;
        WeaponData.behaviorID = 0
    }

    let enemy1 = {
        CommonEntityData.id = id;
        CommonEntityData.position = (xPos, yPos);
        CommonEntityData.speed = 2.0;
        CommonEntityData.data = EntityType.Enemy {
            health = 10;
            weapon = tempWeapon;
            effects = [];
            enemyType = "Tracker"
        }
        CommonEntityData.sprite = "yay"
    }
    
    

    let entitiesMap = 
        Map.empty.
            Add(enemy1.id, enemy1)
    let elist = Map.toList entitiesMap
    let allEntities = join GameState.instance.entities entitiesMap
    let enemySpawnIds = [enemy1.id]
    let allSpawnIds = GameState.instance.spawnIds @ enemySpawnIds
    GameState.instance <- { gs with entities = allEntities; spawnIds = allSpawnIds; nextid = GameState.instance.nextid + 1 }
    

    ()
    

let generateEntities (level : int) = 
    [1..level] |> List.iter assignPositions







