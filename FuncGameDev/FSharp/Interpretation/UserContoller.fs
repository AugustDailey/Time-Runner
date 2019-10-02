namespace FSharp.Interpretation

open UnityEngine

type UserControllerScript() =
    inherit MonoBehaviour()
    member this.Update() =
        if Input.GetKeyDown(KeyCode.RightArrow)
            then Debug.Log("Player moved right. Call move right function here.")
        if Input.GetKeyDown(KeyCode.LeftArrow)
            then Debug.Log("Player moved left. Call move left function here.")
        if Input.GetKeyDown(KeyCode.UpArrow)
            then Debug.Log("Player moved up. Call move up function here.")
        if Input.GetKeyDown(KeyCode.DownArrow)
            then Debug.Log("Player moved down. Call move down function here.")

