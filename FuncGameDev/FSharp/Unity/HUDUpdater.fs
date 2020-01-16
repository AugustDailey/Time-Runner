namespace FSharp.Unity

open UnityEngine


// This script must be placed on a gameobject called HUD with a TextMesh
type HUDUpdater() = 
    inherit MonoBehaviour()
    
    member this.Update() = 
        let camera = GameObject.Find("Main Camera")
        let txt = this.GetComponent<TextMesh>()
        txt.text <- "Time: 100" // grab time from where ever it is
        this.transform.position <- new Vector3(0.0f, 4.5f, 5.0f) + camera.transform.position
        ()