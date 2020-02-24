namespace FSharp.Unity

open UnityEngine
open UnityEngine.SceneManagement

type MultiplayerUpdater() = 
    inherit MonoBehaviour()

    let highScores = ScoreSavingService.getScores
    let highestFloor = highScores.[0]
    let highestRemaining = highScores.[1]
    let lowestTotal = highScores.[2]

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

        let p2cm = {
            ControlModel.down = "s";
            ControlModel.up = "w";
            ControlModel.left = "a";
            ControlModel.right = "d";
            ControlModel.melee = "j";
            ControlModel.range = "k";
            ControlModel.active = ";";
            ControlModel.dodge = "l"
        }

        Spawner.spawnPlayer (GameState.instance.level.stairpos |> fst |> float, GameState.instance.level.stairpos |> snd |> float) p1cm
        Spawner.spawnPlayer (GameState.instance.level.stairpos |> fst |> float, GameState.instance.level.stairpos |> snd |> float) p2cm
        
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
            match highestRemaining with
            | highestRemaining when highestRemaining |> float < GameState.instance.gamedata.time ->
                match lowestTotal with
                | lowestTotal when lowestTotal |> float > GameState.instance.gamedata.totaltime ->
                    ScoreSavingService.storeScores ([|"11"; GameState.instance.gamedata.time |> string; GameState.instance.gamedata.totaltime |> string|])
                | _ ->
                    ScoreSavingService.storeScores ([|"11"; GameState.instance.gamedata.time |> string; lowestTotal|])
            | _ -> 
                match lowestTotal with
                | lowestTotal when lowestTotal |> float > GameState.instance.gamedata.totaltime ->
                    ScoreSavingService.storeScores ([|"11"; highestRemaining; GameState.instance.gamedata.totaltime |> string|])
                | _ ->
                    ScoreSavingService.storeScores ([|"11"; highestRemaining; lowestTotal|])
            "GameOver" |> SceneManager.LoadScene
        | _ -> 
            match GameState.instance.gamedata.time with
            | 0.0 -> 
                match highestFloor with 
                | highestFloor when highestFloor |> int < GameState.instance.gamedata.floor ->
                    ScoreSavingService.storeScores ([|GameState.instance.gamedata.floor |> string; highestRemaining; lowestTotal|])
                | _ -> ()
                "GameOver" |> SceneManager.LoadScene
            | _ -> ()
        ()