namespace FSharp.Unity

open UnityEngine


// This script must be placed on a gameobject called HUD with a TextMesh
type HUDFloorUpdate() = 
  inherit MonoBehaviour()
  
  member this.Update() = 
      let camera = GameObject.Find("Main Camera")
      let txt = this.GetComponent<TextMesh>()
      let floor : int = int GameState.instance.gamedata.floor
      let floor_string : string = string floor
      txt.text <- "Floor: " + floor_string
      this.transform.position <- new Vector3(14.0f, 7.5f, 5.0f) + camera.transform.position
      ()