namespace FSharp.Unity

open UnityEngine


// This script must be placed on a gameobject called HUD with a TextMesh
type HUDUpdater() = 
    inherit MonoBehaviour()
    
    member this.Update() = 
        let camera = GameObject.Find("Main Camera")
        let txt = this.GetComponent<TextMesh>()
<<<<<<< HEAD
        let time : int = int GameState.instance.gamedata.time
        let time_string : string = string time
        txt.text <- "Time: " + time_string
=======
        txt.text <- "Time: 100" // grab time from where ever it is
>>>>>>> 472bb3b2ebd6328ec85f97455568f82fb7ed3536
        this.transform.position <- new Vector3(0.0f, 4.5f, 5.0f) + camera.transform.position
        ()