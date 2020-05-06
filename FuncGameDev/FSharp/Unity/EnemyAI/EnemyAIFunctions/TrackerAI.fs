module TrackerAI

open UnityEngine
open System

let ai id =
    match List.length GameState.instance.playerPos > 0 with
    | true ->
        let enemy = GameState.instance.entities.TryFind(id);
        let epos = enemy.Value.position
        let enemyPos = new Vector3(float32(fst epos), float32(snd epos))

        let closestPlayerPos = EnemyAIUtils.getClosestPlayer epos GameState.instance.playerPos
        let playerPos = new Vector3(float32(fst closestPlayerPos), float32(snd closestPlayerPos))
        let result = playerPos - enemyPos
        let direction = Vector3.Normalize(result)
        let angle = Math.Atan2(float(direction.y), float(direction.x))
        let degreeAngle = angle * float(Mathf.Rad2Deg)
        CommonEntityBehavior.move id degreeAngle |> Commands.addCommand
    | false ->
        ()