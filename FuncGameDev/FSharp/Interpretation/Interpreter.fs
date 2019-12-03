module Interpreter

open UnityEngine

let MovePlayerRight id = CommonEntityBehavior.move id 0.0 Time.deltaTime |> Commands.addCommand
let MovePlayerLeft id = CommonEntityBehavior.move id 180.0 Time.deltaTime |> Commands.addCommand
let MovePlayerUp id = CommonEntityBehavior.move id 90.0 Time.deltaTime |> Commands.addCommand
let MovePlayerDown id = CommonEntityBehavior.move id 270.0 Time.deltaTime |> Commands.addCommand
