module JumperAI

open UnityEngine
open System

let ai id =
    // TODO: Modify this to pick a random player or maybe the closest player later on
    let player = GameStateUtils.getEntityByID GameState.instance 1

    let time = GameState.instance.gamedata.time
    let isJumping = (((time*2.0 |> int) % 3) = 0)
    match isJumping with
    | true ->
        TrackerAI.ai id
    | false ->
        ()
