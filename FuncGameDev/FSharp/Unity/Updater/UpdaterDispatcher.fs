module UpdaterDispatcher

open UnityEngine

let updateDispatch (entityData:CommonEntityData.T) (gameObject:GameObject) = 
    match entityData.data with
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
    CommonEntityUpdater.update entityData gameObject
    updateDispatch entityData gameObject
    ()

let updateAllGameObjects (gs:GameState.T) (gameObjects:GameObject list) =
    let callUpdaterWithGameState = updateObject gs
    gameObjects |> List.iter callUpdaterWithGameState
    ()
