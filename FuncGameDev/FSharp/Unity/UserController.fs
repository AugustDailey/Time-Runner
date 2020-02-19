module UserController

// entity and player are the same thing, just the different versions of it's data
open UnityEngine

let checkRight id (player:PlayerData.T) (entity:CommonEntityData.T) (model:ControlModel.T) = 
    if Input.GetKey(model.right)
        then Interpreter.MovePlayerRight id
 
let checkLeft id (player:PlayerData.T) (entity:CommonEntityData.T) (model:ControlModel.T) = 
    if Input.GetKey(model.left)
        then Interpreter.MovePlayerLeft id

let checkUp id (player:PlayerData.T) (entity:CommonEntityData.T) (model:ControlModel.T) = 
    if Input.GetKey(model.up)
        then Interpreter.MovePlayerUp id

let checkDown id (player:PlayerData.T) (entity:CommonEntityData.T) (model:ControlModel.T) = 
    if Input.GetKey(model.down)
        then Interpreter.MovePlayerDown id

let checkLeftUp id (player:PlayerData.T) (entity:CommonEntityData.T) (model : ControlModel.T) =
    if Input.GetKey(model.left) && Input.GetKey(model.up)
        then Interpreter.MoveEntityInDirection id 135.0
        
let checkLeftDown id (player:PlayerData.T) (entity:CommonEntityData.T) (model : ControlModel.T) =
    if Input.GetKey(model.left) && Input.GetKey(model.down)
        then Interpreter.MoveEntityInDirection id 225.0

let checkRightUp id (player:PlayerData.T) (entity:CommonEntityData.T) (model : ControlModel.T) =
    if Input.GetKey(model.right) && Input.GetKey(model.up)
        then Interpreter.MoveEntityInDirection id 45.0
        
let checkRightDown id (player:PlayerData.T) (entity:CommonEntityData.T) (model : ControlModel.T) =
    if Input.GetKey(model.right) && Input.GetKey(model.down)
        then Interpreter.MoveEntityInDirection id 315.0

let checkMelee id (player:PlayerData.T) (entity:CommonEntityData.T) (model:ControlModel.T) = 
    if Input.GetKeyDown(model.melee)
        then Interpreter.ActivateWeapon player.melee id entity.position entity.direction

let checkRoll id (player:PlayerData.T) (entity:CommonEntityData.T) (model:ControlModel.T) = 
    if Input.GetKeyDown(model.dodge)
        then Interpreter.ActivateWeapon player.roll id entity.position entity.direction

let checkRanged id (player:PlayerData.T) (entity:CommonEntityData.T) (model:ControlModel.T) = 
    if Input.GetKeyDown(model.range)
        then Interpreter.ActivateWeapon player.ranged id entity.position entity.direction

let checkActive id (player:PlayerData.T) (entity:CommonEntityData.T) (model:ControlModel.T) = 
    if Input.GetKeyDown(model.active)
        then Interpreter.ActivateWeapon player.active id entity.position entity.direction


let queryInput eid (player:PlayerData.T) (entity:CommonEntityData.T) =
    let model = player.controlModel
    let controlQueryFunctionList = [checkRight ; checkLeft ; checkUp ; checkDown ; checkLeftUp ; checkLeftDown ; checkRightUp ; checkRightDown ; checkMelee ; checkRoll ; checkRanged ; checkActive]
    controlQueryFunctionList |> List.map (fun x -> x eid) |> List.map (fun x -> x player) |> List.map (fun x -> x entity) |> List.map (fun x -> x model)
    ()

let tryQueryInput eid (entity:CommonEntityData.T) =
    match entity.data with
    | EntityType.Player player ->
        queryInput eid player entity
    | _ ->
        ()
