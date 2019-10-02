namespace FSharp.Interpretation

open UnityEngine

type UserControllerScript() =
    inherit MonoBehaviour()
    member this.Update() =
        if Input.GetKeyDown(KeyCode.RightArrow)
            then Debug.Log("Player moved right")
            elif Input.GetKeyDown(KeyCode.LeftArrow)
                then Debug.Log("Player moved left")
                elif Input.GetKeyDown(KeyCode.UpArrow)
                    then Debug.Log("Player moved up")
                    elif Input.GetKeyDown(KeyCode.DownArrow)
                        then Debug.Log("Player moved down")

