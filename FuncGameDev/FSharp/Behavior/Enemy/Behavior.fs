module EnemyBehavior

let spawn xy bid (gs:GameState.T) =
    let enemyBehavior = Map.find bid EnemyBehaviorTable.Instance
    enemyBehavior.spawn xy bid gs |> GameStateUtils.modifyForSpawn