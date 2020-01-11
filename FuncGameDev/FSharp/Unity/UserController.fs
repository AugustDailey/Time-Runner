module UserController

open UnityEngine

let checkRight id (model : ControlModel.T) = 
    if Input.GetKey(model.right)
        then Interpreter.MovePlayerRight id

let checkLeft id (model : ControlModel.T) = 
    if Input.GetKey(model.left)
        then Interpreter.MovePlayerLeft id
    
let checkUp id (model : ControlModel.T) = 
    if Input.GetKey(model.up)
        then Interpreter.MovePlayerUp id

let checkDown id (model : ControlModel.T) = 
    if Input.GetKey(model.down)
        then Interpreter.MovePlayerDown id


let queryInput eid (player:PlayerData.T) =
    let model = player.controlModel
    let controlQueryFunctionList = [checkRight ; checkLeft ; checkUp ; checkDown]
    controlQueryFunctionList |> List.map (fun x -> x eid) |> List.map (fun x -> x model)
    ()


let tryQueryInput eid (entity:CommonEntityData.T) =
    match entity.data with
    | EntityType.Player player ->
        queryInput eid player
    | _ ->
        ()

