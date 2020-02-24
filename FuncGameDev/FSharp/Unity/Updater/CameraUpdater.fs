module CameraUpdater

open UnityEngine

let update() =
    
    let cameraData = GameState.instance.gamedata.camera
    let unityCameraTransform = Camera.main.transform

    let pos = cameraData.position
    let rot = cameraData.rotation
    let scale = cameraData.scale

    let posV = new Vector3(fst pos |> float32, snd pos |> float32, unityCameraTransform.transform.position.z)
    let rotV = new Quaternion(fst rot |> float32, snd rot |> float32, unityCameraTransform.transform.rotation.z, unityCameraTransform.transform.rotation.w)
    let scaleV = new Vector3(fst scale |> float32, snd scale |> float32, unityCameraTransform.transform.localScale.z)
    match cameraData.shakeTime > 0.0 with
    | true ->
        let random = new System.Random()
        let randomX = posV.x + ((random.Next(3) - 1) |> float32)
        let randomY = posV.y + ((random.Next(3) - 1) |> float32)
        Camera.main.transform.position <- new Vector3(randomX, randomY, posV.z)
    | false ->
        Camera.main.transform.position <- posV
    Camera.main.transform.rotation <- rotV
    Camera.main.transform.localScale <- scaleV
