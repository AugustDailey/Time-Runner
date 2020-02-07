module CameraUpdater

open UnityEngine

let update =
    
    let cameraData = GameState.instance.gamedata.camera
    let unityCameraTransform = Camera.main.transform

    let pos = cameraData.position
    let rot = cameraData.rotation
    let scale = cameraData.scale

    let posV = new Vector3(fst pos |> float32, snd pos |> float32, unityCameraTransform.transform.position.z)
    let rotV = new Quaternion(fst rot |> float32, snd rot |> float32, unityCameraTransform.transform.rotation.z, unityCameraTransform.transform.rotation.w)
    let scaleV = new Vector3(fst scale |> float32, snd scale |> float32, unityCameraTransform.transform.localScale.z)

    Camera.main.transform.position <- posV
    Camera.main.transform.rotation <- rotV
    Camera.main.transform.localScale <- scaleV


    ()
