module UserController

// entity and player are the same thing, just the different versions of it's data
open UnityEngine

let checkRight id (player : PlayerData.T) (entity:CommonEntityData.T) (model : ControlModel.T) = 
    if Input.GetKey(model.right)
        then Interpreter.MovePlayerRight id

let checkLeft id (player : PlayerData.T) (entity:CommonEntityData.T) (model : ControlModel.T) = 
    if Input.GetKey(model.left)
        then Interpreter.MovePlayerLeft id
    
let checkUp id (player : PlayerData.T) (entity:CommonEntityData.T) (model : ControlModel.T) = 
    if Input.GetKey(model.up)
        then Interpreter.MovePlayerUp id

let checkDown id (player : PlayerData.T) (entity:CommonEntityData.T) (model : ControlModel.T) = 
    if Input.GetKey(model.down)
        then Interpreter.MovePlayerDown id

let checkMelee id (player : PlayerData.T) (entity:CommonEntityData.T) (model : ControlModel.T) = 
    let xy = entity.position |> fst // This will probably need to change
    if Input.GetKey(model.melee)
        then Interpreter.ActivateWeapon_2 player.melee id xy 0.0

let checkRoll id (player : PlayerData.T) (entity:CommonEntityData.T) (model : ControlModel.T) = 
    let xy = entity.position |> fst // This will probably need to change
    if Input.GetKey(model.dodge)
        then Interpreter.ActivateWeapon_2 player.roll id xy 0.0

let checkRanged id (player : PlayerData.T) (entity:CommonEntityData.T) (model : ControlModel.T) = 
    let xy = entity.position |> fst // This will probably need to change
    if Input.GetKey(model.range)
        then Interpreter.ActivateWeapon_2 player.ranged id xy 0.0

let checkActive id (player : PlayerData.T) (entity:CommonEntityData.T) (model : ControlModel.T) = 
    let xy = entity.position |> fst // This will probably need to change
    if Input.GetKey(model.active)
        then Interpreter.ActivateWeapon_2 player.active id xy 0.0




let queryInput eid (player:PlayerData.T) (entity:CommonEntityData.T) =
    let model = player.controlModel
    let controlQueryFunctionList = [checkRight ; checkLeft ; checkUp ; checkDown ; checkMelee ; checkRoll ; checkRanged ; checkActive]
    controlQueryFunctionList |> List.map (fun x -> x eid) |> List.map (fun x -> x player) |> List.map (fun x -> x entity) |> List.map (fun x -> x model)
    ()

let tryQueryInput eid (entity:CommonEntityData.T) =
    match entity.data with
    | EntityType.Player player ->
        queryInput eid player entity
    | _ ->
        ()

