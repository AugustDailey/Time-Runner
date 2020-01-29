module TrackerAI

open UnityEngine
open System

let ai id =
    // TODO: Modify this to pick a random player or maybe the closest player later on
    let player = GameState.instance.entities.TryFind(1);
    match player with
    | Some value ->
        let pPosVector = player.Value.position
        let playerPos = new Vector3(float32(fst pPosVector), float32(snd pPosVector))

        let enemy = GameState.instance.entities.TryFind(id);
        let epos = enemy.Value.position
        let enemyPos = new Vector3(float32(fst epos), float32(snd epos))

        let result = playerPos - enemyPos
        let direction = Vector3.Normalize(result)
        let angle = Math.Atan2(float(direction.y), float(direction.x))
        let degreeAngle = angle * float(Mathf.Rad2Deg)
        CommonEntityBehavior.move id degreeAngle Time.deltaTime |> Commands.addCommand
    | None ->
        ()