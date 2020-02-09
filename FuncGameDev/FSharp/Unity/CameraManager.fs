module CameraManager

open UnityEngine

let updateCamera() = 
    let camera = Camera.main
    let transform = camera.transform

    let cPosX = transform.position.x |> float
    let cPosY = transform.position.y |> float
    let pos = (cPosX, cPosY)

    let cRotX = transform.rotation.x |> float
    let cRotY = transform.rotation.y |> float
    let rot = (cRotX, cRotY)

    let cScaleX = transform.localScale.x |> float
    let cScaleY = transform.localScale.y |> float
    let scale = (cScaleX, cScaleY)

    CameraInterpreter.updateCamera pos rot scale 20.0 10.0