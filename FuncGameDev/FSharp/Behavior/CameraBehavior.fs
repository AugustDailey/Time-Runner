module CameraBehavior

let updateCamera (pos : float*float) (rot : float*float) (scale : float*float) (width : float) (height : float) (gs : GameState.T) =  

    let cPosX = fst pos
    let cPosY = snd pos

    let cRotX = fst rot
    let cRotY = snd rot

    let cScaleX = fst scale
    let cScaleY = snd scale


    let cd : CameraData.T = { 
        position = (cPosX, cPosY);
        rotation = (cRotX, cRotY);
        scale = (cScaleX, cScaleY);
        width = 20.0;
        height = 10.0 }
    let gd : GameData.T = { gs.gamedata with camera = cd}

    { gs with gamedata = gd }