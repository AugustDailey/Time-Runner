namespace FSharp.Unity

open UnityEngine

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

