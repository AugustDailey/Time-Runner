module CameraManager

open UnityEngine

let updateCamera() = 
    let camera = Camera.main
    let transform = camera.transform

    CameraInterpreter.tickCamera (Time.deltaTime |> float)