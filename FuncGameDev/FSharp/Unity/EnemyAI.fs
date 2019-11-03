namespace FSharp.Unity

open UnityEngine

type UserControllerScript() =
    inherit MonoBehaviour()

    // AI that randomly moves the enemy in a Cardinal direction
    let randomEnemyAI id = 
        let rand = Random.Next(4);
        // left
        if rand < 1 then Commands.addCommand CommonEntityBehavior.move 180 Time.deltaTime
        // right
        elif rand < 2 then Commands.addCommand CommonEntityBehavior.move 0 Time.deltaTime
        // up
        elif rand < 3 then Commands.addCommand CommonEntityBehavior.move 90 Time.deltaTime
        // down 
        else Commands.addCommand CommonEntityBehavior.move 270 Time.deltaTime

    let callEnemyAI id =
        match GameState.T.entities[id].entity with
        | EntityType.Enemy -> randomEnemyAI id
        | _ -> -1

    member this.Update() =
        [1..GameState.T.entities.Count] |> List.map callEnemyAI