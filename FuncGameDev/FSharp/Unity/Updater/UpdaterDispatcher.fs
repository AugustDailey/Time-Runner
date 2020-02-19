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
        ProjectileUpdater.update entityData projectileData gameObject
        ()
    | EntityType.Weapon weaponData ->
        ()

let updateObject (gs:GameState.T) eid (gameObjectWrapper:GameObjectWrapper.T) =
    let id = gameObjectWrapper.id
    let entityData = GameStateUtils.getEntityByID gs id
    CommonEntityUpdater.update entityData gameObjectWrapper.go
    updateDispatch entityData gameObjectWrapper.go
    ()

let updateAllGameObjects (gs:GameState.T) (gameObjects:Map<int, GameObjectWrapper.T>) =
    let callUpdaterWithGameState = updateObject gs
    gameObjects |> Map.iter callUpdaterWithGameState
    ()
