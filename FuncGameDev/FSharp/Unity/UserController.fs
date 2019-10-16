namespace FSharp.Unity

open UnityEngine

type UserControllerScript() =
    inherit MonoBehaviour()

    let mutable Players : Collections.Map<int, ControlModel.T> = Map.ofList[ (1, {right = "right"; left = "left"; up = "up"; down = "down"})]

    let checkRight id (model : ControlModel.T) = 
        if Input.GetKeyDown(model.right)
            then Interpreter.MovePlayerRight id

    let checkLeft id (model : ControlModel.T) = 
        if Input.GetKeyDown(model.left)
            then Interpreter.MovePlayerLeft id
    
    let checkUp id (model : ControlModel.T) = 
        if Input.GetKeyDown(model.up)
            then Interpreter.MovePlayerUp id

    let checkDown id (model : ControlModel.T) = 
        if Input.GetKeyDown(model.down)
            then Interpreter.MovePlayerDown id


    let queryInput id =
        let model = Players.[id]
        checkRight id model
        checkLeft id model
        checkUp id model
        checkDown id model
        ()

    member this.Update() =
        [1..Players.Count] |> List.map queryInput



