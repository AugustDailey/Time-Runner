module CameraInterpreter

open UnityEngine

let GetCameraWidth = GameState.instance.gamedata.camera.width
let GetCameraHeight = GameState.instance.gamedata.camera.height
let GetCameraPosition = GameState.instance.gamedata.camera.position

let updateCamera pos rot scale width height = CameraBehavior.updateCamera pos rot scale width height |> Commands.addCommand
