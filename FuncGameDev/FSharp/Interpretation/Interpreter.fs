module Interpreter

let MovePlayerRight id = CommonEntityBehavior.move id (1.0/60.0) 0.0 |> Commands.addCommand
let MovePlayerLeft id = CommonEntityBehavior.move id (1.0/60.0) 180.0 |> Commands.addCommand
let MovePlayerUp id = CommonEntityBehavior.move id (1.0/60.0) 90.0 |> Commands.addCommand
let MovePlayerDown id = CommonEntityBehavior.move id (1.0/60.0) 270.0 |> Commands.addCommand
