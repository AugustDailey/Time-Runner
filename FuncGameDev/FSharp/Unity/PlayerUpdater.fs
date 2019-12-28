namespace FSharp.Unity

open UnityEngine

// I'd like to remove this soon and replace it with more general updaters
//so we don't need all these scripts floating around, if possible. 
type PlayerUpdateScript() = 
    inherit MonoBehaviour()

    [<SerializeField>]
    let mutable gO = null

    member this.Start() =
        gO = (GameObject) null

    member this.Update() =
        this.UpdatePosition()

    member this.UpdatePosition() =
        gO.transform.position <- StateManager.GetPosition 0

