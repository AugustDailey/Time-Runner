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
        Debug.Log(gO.transform.position)
        gO.transform.position <- gO.transform.position + new Vector3(1.0f, 0.0f, 0.0f)

