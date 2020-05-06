module UpdateLoop

open UnityEngine

let Updateloop() = 
    CameraManager.updateCamera ()
    GameState.instance <- GameObjectWrapper.wrappers |> CommonEntityUpdater.updateGameStateEntities GameState.instance
    Time.deltaTime |> float |> GameDataUtils.decreaseTime |> Commands.addCommand
    GameState.instance <- PlayerUpdater.updatePlayerPos GameState.instance
    UpdaterDispatcher.issueUpdateCommands GameState.instance GameObjectWrapper.wrappers
    GameState.instance.entities |> Map.iter UserController.tryQueryInput
    GameState.instance.entities |> Map.iter EnemyAIScript.callEnemyAI
    GameState.instance <- Commands.executeAllCommands GameState.instance
    UpdaterDispatcher.updateAllGameObjects GameState.instance GameObjectWrapper.wrappers
    Spawner.spawnGameObjects GameState.instance |> Map.iter (fun key value -> GameObjectWrapper.addWrapper value)
    Generator.tryGenerateLevel GameState.instance
    GameState.instance <- GameStateUtils.removeMarkedEntities GameState.instance
    GameState.instance.killIds |> Destroyer.update
    LevelUpdater.update ()
    ()
