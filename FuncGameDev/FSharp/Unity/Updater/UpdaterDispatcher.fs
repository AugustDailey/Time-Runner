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

let updateObject (gs:GameState.T) (gameObjectWrapper:GameObjectWrapper.T) =
    let id = gameObjectWrapper.id
    let entityData = GameStateUtils.getEntityByID gs id
    CommonEntityUpdater.update entityData gameObjectWrapper.go
    updateDispatch entityData gameObjectWrapper.go
    ()

let updateAllGameObjects (gs:GameState.T) (gameObjects:GameObjectWrapper.T list) =
    let callUpdaterWithGameState = updateObject gs
    gameObjects |> List.iter callUpdaterWithGameState
    ()
