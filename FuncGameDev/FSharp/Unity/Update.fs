namespace FSharp.Unity

open UnityEngine

type Updater() = 
    inherit MonoBehaviour()

    //[<SerializeField>]
    //let mutable gameObjects: GameObjectWrapper.T list = List.empty

    // TODO: THIS VARIABLE SHOULD BE REMOVED ONCE WE COMPLETE TIMER DISPLAY
    let mutable lastTime = GameState.instance.gamedata.time |> int

    member this.Start() =
        Spawner.spawnPlayer (2.0, 1.0)
        //Spawner.spawnEnemy (-1.0, 0.0) 1
        //Spawner.spawnEnemy (-2.0, -1.0) 2
        //Spawner.spawnItem (-3.0, -2.5) 1
        //Spawner.spawnWeapon (-3.5, 2.5) 1
        //Spawner.spawnWeapon (-2.0, 2.5) 2
        ()

    member this.Update() =

        // TODO: THIS BLOCK SHOULD BE REMOVED ONCE WE COMPLETE TIMER DISPLAY
        // it's just here so that we only print each time increment once rather than spamming the console with it
        let time = GameState.instance.gamedata.time |> int
        if time <> lastTime then Debug.Log("TIME: " + time.ToString());
        lastTime <- time

        Time.deltaTime |> float |> GameDataUtils.decreaseTime |> Commands.addCommand
        GameState.instance.entities |> Map.iter UserController.tryQueryInput
        GameState.instance.entities |> Map.iter EnemyAIScript.callEnemyAI
        GameState.instance <- Commands.executeAllCommands GameState.instance
        UpdaterDispatcher.updateAllGameObjects GameState.instance GameObjectWrapper.wrappers
        let newGameObjects = Spawner.spawnGameObjects GameState.instance
        newGameObjects |> Map.iter (fun key value -> GameObjectWrapper.addWrapper value)
        GameState.instance <- GameStateUtils.removeMarkedEntities GameState.instance
        GameState.instance.killIds |> Destroyer.update
        ()
