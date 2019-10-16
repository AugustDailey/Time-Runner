module Interpreter

let MovePlayerRight id = CommonEntityBehavior.move id 0.0 |> Commands.addCommand
let MovePlayerLeft id = CommonEntityBehavior.move id 180.0 |> Commands.addCommand
let MovePlayerUp id = CommonEntityBehavior.move id 90.0 |> Commands.addCommand
let MovePlayerDown id = CommonEntityBehavior.move id 270.0 |> Commands.addCommand
