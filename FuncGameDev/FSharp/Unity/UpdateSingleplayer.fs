namespace FSharp.Unity

open UnityEngine
open UnityEngine.SceneManagement

type SingleplayerUpdater() = 
    inherit MonoBehaviour()

    let highScore = ScoreSavingService.getScore

    member this.Start() =
        GameState.instance <- GameState.createInitialGameState ()
        GameState.instance <- LevelDataService.loadLevelParams GameState.instance
        GameObjectWrapper.wrappers <- Map.empty
        LevelGameObject.stairs <- null
        
        let p1cm = {
            ControlModel.down = "down";
            ControlModel.up = "up";
            ControlModel.left = "left";
            ControlModel.right = "right";
            ControlModel.melee = "z";
            ControlModel.range = "x";
            ControlModel.active = "v";
            ControlModel.dodge = "c"
        }
        
        Spawner.spawnPlayer (GameState.instance.level.stairpos |> fst |> float, GameState.instance.level.stairpos |> snd |> float) p1cm
        Generator.generateLevel GameState.instance
        ()

    member this.Update() =
        UpdateLoop.Updateloop ()
        CameraUpdater.update ()
        this.checkGameOver ()
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