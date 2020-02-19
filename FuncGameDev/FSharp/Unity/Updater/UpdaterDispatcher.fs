module UpdaterDispatcher

open UnityEngine

let updateDispatch (entityData:CommonEntityData.T) (gameObject:GameObject) = 
    match entityData.data with
    | EntityType.Player playerData ->
        PlayerUpdater.update entityData playerData gameObject
        ()
    | EntityType.Enemy enemyData ->
        EnemyUpdater.update entityData enemyData gameObject
        ()
    | EntityType.Item itemData ->
        ItemUpdater.update entityData itemData gameObject
        ()
    | EntityType.Projectile projectileData ->
        ProjectileUpdater.update entityData projectileData gameObject
        ()
    | EntityType.Weapon weaponData ->
        WeaponUpdater.update entityData weaponData gameObject
        ()

let updateObject (gs:GameState.T) eid (gameObjectWrapper:GameObjectWrapper.T) =
    let id = gameObjectWrapper.id
    let entityData = GameStateUtils.getEntityByID gs id
    CommonEntityUpdater.update entityData gameObjectWrapper.go
    ()

let updateAllGameObjects (gs:GameState.T) (gameObjects:Map<int, GameObjectWrapper.T>) =
    let callUpdaterWithGameState = updateObject gs
    gameObjects |> Map.iter callUpdaterWithGameState
    ()

let issueUpdateCommand (gs:GameState.T) eid (gameObjectWrapper:GameObjectWrapper.T) =
    let id = gameObjectWrapper.id
    let entityData = GameStateUtils.getEntityByID gs id
    updateDispatch entityData gameObjectWrapper.go

let issueUpdateCommands (gs:GameState.T) (gameObjects:Map<int, GameObjectWrapper.T>) =
    let callDispatchWithGameState = issueUpdateCommand gs
    gameObjects |> Map.iter callDispatchWithGameState
    ()
