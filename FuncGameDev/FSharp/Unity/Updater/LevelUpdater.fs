module LevelUpdater

open UnityEngine

let update() =
    let levelData = GameState.instance.level
    match levelData.stairsSpawned with
    | true -> // if stairs are supposed to be spawned, move them to their normal position
        LevelGameObject.stairs.transform.position <- new Vector3(levelData.stairpos |> fst |> float32, levelData.stairpos |> snd |> float32)
    | false -> // if stairs aren't supposed to be spawned (e.g. boss is alive), move them offscreen
        LevelGameObject.stairs.transform.position <- new Vector3(-100.0f, -100.0f)
