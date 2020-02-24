namespace FSharp.Unity

open UnityEngine
open UnityEngine.SceneManagement

type Updater() = 
    inherit MonoBehaviour()

    let highScore = ScoreSavingService.getScore

    member this.Start() =
        GameState.instance <- GameState.createInitialGameState ()
        GameObjectWrapper.wrappers <- Map.empty
        LevelGameObject.stairs <- null

        let p1cm = {
            ControlModel.down = "down";
            ControlModel.up = "up";
            ControlModel.left = "left";
            ControlModel.right = "right";
            ControlModel.melee = "j";
            ControlModel.range = "k";
            ControlModel.active = "l";
            ControlModel.dodge = ";"
        }

        let p2cm = {
            ControlModel.down = "s";
            ControlModel.up = "w";
            ControlModel.left = "a";
            ControlModel.right = "d";
            ControlModel.melee = "z";
            ControlModel.range = "x";
            ControlModel.active = "v";
            ControlModel.dodge = "c"
        }

        Spawner.spawnPlayer (GameState.instance.level.stairpos |> fst |> float, GameState.instance.level.stairpos |> snd |> float) p1cm
        Spawner.spawnPlayer (GameState.instance.level.stairpos |> fst |> float, GameState.instance.level.stairpos |> snd |> float) p2cm

        Generator.generateLevel GameState.instance
        ()

    member this.Update() =
        CameraManager.updateCamera()
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
        CameraUpdater.update()
        this.checkGameOver()
        ()

    member this.checkGameOver() =
        match GameState.instance.gamedata.floor with 
        | 11 ->
            match highScore with
            | highScore when highScore |> float > GameState.instance.gamedata.time ->
                ScoreSavingService.storeScore (GameState.instance.gamedata.time |> string)
            | _ -> ()
            "GameOver" |> SceneManager.LoadScene
        | _ -> 
            match GameState.instance.gamedata.time with
            | 0.0 -> 
                "GameOver" |> SceneManager.LoadScene
            | _ -> ()
        ()
