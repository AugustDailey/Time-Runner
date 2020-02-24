module CameraInterpreter

open UnityEngine

let GetCameraWidth = GameState.instance.gamedata.camera.width
let GetCameraHeight = GameState.instance.gamedata.camera.height
let GetCameraPosition = GameState.instance.gamedata.camera.position
let GetCameraRotation = GameState.instance.gamedata.camera.rotation
let GetCameraScale = GameState.instance.gamedata.camera.scale

let updateCamera delta pos rot scale width height = CameraBehavior.updateCamera delta pos rot scale width height |> Commands.addCommand
let tickCamera delta = CameraBehavior.updateCamera delta GetCameraPosition GetCameraRotation GetCameraScale GetCameraWidth GetCameraHeight |> Commands.addCommand
