module UpdaterDispatcher

open UnityEngine

let generalUpdate (entityData:CommonEntityData.T) (gameObject:GameObject) =
    let x = entityData.position |> fst |> float32
    let y = entityData.position |> snd |> float32
    gameObject.transform.position.x = x
    gameObject.transform.position.y = y

let specificUpdate (entityData:CommonEntityData.T) (gameObject:GameObject) = 
    match entityData.entity with
    | EntityType.Player playerData ->
        PlayerUpdater.update entityData playerData gameObject
        ()
    | EntityType.Enemy enemyData ->
        ()
    | EntityType.Item itemData ->
        ()
    | EntityType.Projectile projectileData ->
        ()
    | EntityType.Weapon weaponData ->
        ()

let updateObject (gs:GameState.T) (gameObject:GameObject) =
    let id = gameObject.GetInstanceID()
    let entityData = GameStateUtils.getEntityByID gs id
    generalUpdate entityData gameObject
    specificUpdate entityData gameObject
    ()

let updateAllGameObjects (gs:GameState.T) (gameObjects:GameObject list) =
    let callUpdaterWithGameState = updateObject gs
    gameObjects |> List.iter callUpdaterWithGameState
    ()
