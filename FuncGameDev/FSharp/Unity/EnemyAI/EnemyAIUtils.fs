module EnemyAIUtils

let getCloserPosToPos (enemyPos: float*float) (pos1: float*float) (pos2: float*float) =
    let dist1 = sqrt (((fst enemyPos - fst pos1) ** 2.0) + ((snd enemyPos - snd pos1) ** 2.0))
    let dist2 = sqrt (((fst enemyPos - fst pos2) ** 2.0) + ((snd enemyPos - snd pos2) ** 2.0))
    match dist1 <= dist2 with
    | true -> pos1
    | false -> pos2

let getClosestPlayer (enemyPos: float*float) (playerPos: (float*float) list) =
    let getCloserPos = getCloserPosToPos enemyPos
    List.reduce getCloserPos playerPos