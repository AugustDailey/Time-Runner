module GolemBossAI

open UnityEngine
open System

let ai id =
    // TODO: Modify this to pick a random player or maybe the closest player later on
    let player = GameStateUtils.getEntityByID GameState.instance 1
    let enemy = GameStateUtils.getEntityByID GameState.instance id



    let enraged = match enemy.data with
    | EntityType.Enemy data ->
        data.health <= 750
    | _ ->
        false

    let speedMult = match enraged with
    | false -> 1.0
    | true -> 2.0

    let time = GameState.instance.gamedata.time
    let step = (time*4.0 |> int) % 32
    let isThrowing = match enraged with
    | false -> (step = 0 or step = 1)
    | true -> (step = 0 or step = 1 or step = 16 or step = 17)
    let isCharging = match enraged with
    | false -> (step = 16 or step = 17 or step = 18)
    | true -> (step = 8 or step = 9 or step = 24 or step = 25)
    let isWalking = match enraged with 
    | false -> (step % 4 = 0 or step % 4 = 1)
    | true -> (step % 2 = 1)
    
    match isThrowing with
    | true ->
        EnemyBehavior.attack id |> Commands.addCommand
    | false ->
        match isCharging with
        | true ->
            EnemyBehavior.updateSpeed id (8.0*speedMult) |> Commands.addCommand
        | false ->
            EnemyBehavior.updateSpeed id (1.5*speedMult) |> Commands.addCommand
        match (isWalking or isCharging) with
        | true ->
            TrackerAI.ai id
        | false ->
            ()