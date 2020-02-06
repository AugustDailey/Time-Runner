module Interpreter

open UnityEngine

let MovePlayerRight id = CommonEntityBehavior.move id 0.0 Time.deltaTime |> Commands.addCommand
let MovePlayerLeft id = CommonEntityBehavior.move id 180.0 Time.deltaTime |> Commands.addCommand
let MovePlayerUp id = CommonEntityBehavior.move id 90.0 Time.deltaTime |> Commands.addCommand
let MovePlayerDown id = CommonEntityBehavior.move id 270.0 Time.deltaTime |> Commands.addCommand

let ActivateWeapon eid wid xy degrees = WeaponBehavior.attack wid eid xy degrees |> Commands.addCommand
let ActivateWeapon_2 weapon eid xy degrees = WeaponBehavior.attack_2 weapon eid xy degrees |> Commands.addCommand

let MoveEntityInDirection id direction = CommonEntityBehavior.move id direction Time.deltaTime |> Commands.addCommand
