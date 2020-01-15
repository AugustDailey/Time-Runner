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
        CommonEntityBehavior.move id 180.0 Time.deltaTime |> Commands.addCommand
    
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