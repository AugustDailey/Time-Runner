module CameraManager

open UnityEngine

let updateCamera() = 
    CameraInterpreter.tickCamera (Time.deltaTime |> float)
