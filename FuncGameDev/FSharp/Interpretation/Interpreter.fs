module Interpreter

open UnityEngine

let MovePlayerRight id = CommonEntityBehavior.move id 0.0 |> Commands.addCommand
let MovePlayerLeft id = CommonEntityBehavior.move id 180.0 |> Commands.addCommand
let MovePlayerUp id = CommonEntityBehavior.move id 90.0 |> Commands.addCommand
let MovePlayerDown id = CommonEntityBehavior.move id 270.0|> Commands.addCommand

let MoveEntityInDirection id direction = CommonEntityBehavior.move id direction |> Commands.addCommand
let ActivateWeapon weapon eid xy degrees = WeaponBehavior.attack weapon eid xy degrees |> Commands.addCommand