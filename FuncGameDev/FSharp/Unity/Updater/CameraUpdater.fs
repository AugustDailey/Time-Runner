module CameraUpdater

open UnityEngine

let update =
    // update camera
    let camera = UnityEngine.Camera.main
    let transform = camera.transform

    let cPosX = transform.position.x |> float
    let cPosY = transform.position.y |> float
    let cPosZ = transform.position.z |> float

    let cRotX = transform.rotation.x |> float
    let cRotY = transform.rotation.y |> float
    let cRotZ = transform.rotation.z |> float

    let cScaleX = transform.localScale.x |> float
    let cScaleY = transform.localScale.y |> float
    let cScaleZ = transform.localScale.z |> float

    let cd : CameraData.T = { 
        position = (cPosX, cPosY, cPosZ);
        rotation = (cRotX, cRotY, cRotZ);
        scale = (cScaleX, cScaleY, cScaleZ);
        width = 20.0;
        height = 10.0 }
    let gd : GameData.T = {
        time = GameState.instance.gamedata.time;
        floor = GameState.instance.gamedata.floor;
        camera = cd }

    let gs = GameState.instance
    GameState.instance <- { gs with gamedata = gd}
    ()
