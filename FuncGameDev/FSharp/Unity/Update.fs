namespace FSharp.Unity

open UnityEngine

type Updater() = 
    inherit MonoBehaviour()

    member this.Start() =
        Generator.generateLevel GameState.instance
        Spawner.spawnPlayer (2.0, 1.0)
        EnemyGenerator.generateEntities [2 ; 2 ; 1 ; 1 ; 1]
        ItemGenerator.generateItems [1 ; 1 ; 1]
        Spawner.spawnWeapon (-3.5, 2.5) 1
        Spawner.spawnWeapon (-2.0, 2.5) 2
        ()

    member this.Update() =
        CameraManager.updateCamera()
        GameState.instance <- GameObjectWrapper.wrappers |> CommonEntityUpdater.updateGameStateEntities GameState.instance
        Time.deltaTime |> float |> GameDataUtils.decreaseTime |> Commands.addCommand
        GameState.instance.entities |> Map.iter UserController.tryQueryInput
        GameState.instance.entities |> Map.iter EnemyAIScript.callEnemyAI
        GameState.instance <- Commands.executeAllCommands GameState.instance
        UpdaterDispatcher.updateAllGameObjects GameState.instance GameObjectWrapper.wrappers
        let newGameObjects = Spawner.spawnGameObjects GameState.instance
        newGameObjects |> Map.iter (fun key value -> GameObjectWrapper.addWrapper value)
        GameState.instance <- GameStateUtils.removeMarkedEntities GameState.instance
        GameState.instance.killIds |> Destroyer.update
        CameraUpdater.update()
        ()
