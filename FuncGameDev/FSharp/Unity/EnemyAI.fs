module EnemyAIScript

open UnityEngine
open System


    // AI that randomly moves the enemy in a Cardinal direction
    let randomEnemyAI id = 
        let randomizer = new Random()
        let rand = randomizer.Next(4)
        // left
        if rand < 1 then CommonEntityBehavior.move id 180.0 Time.deltaTime |> Commands.addCommand
        // right
        elif rand < 2 then  CommonEntityBehavior.move id 0.0 Time.deltaTime |> Commands.addCommand
        // up
        elif rand < 3 then  CommonEntityBehavior.move id 90.0 Time.deltaTime |> Commands.addCommand
        // down 
        else CommonEntityBehavior.move id 270.0 Time.deltaTime |> Commands.addCommand
    
    let trackerAI id =
        
        // TODO: Modify this to pick a random player or maybe the closest player later on
        let player = GameState.instance.entities.TryFind(1);
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
    
    let determineUpdate enemyType id= 
        match enemyType with
        | "Tracker" -> trackerAI id

    let callEnemyAI id (entity:CommonEntityData.T) =
        let entityOption = GameState.instance.entities.TryFind(id)
        match entityOption with
        | None -> ()
        | Some entityData -> match entityData.data with
            | EntityType.Enemy enemy -> determineUpdate enemy.enemyType id
            | _ -> ()

    
    //member this.Update() =
    //    [1..GameState.instance.entities.Count] |> List.map callEnemyAI