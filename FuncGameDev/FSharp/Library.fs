namespace FSharpUnityTutorial

open UnityEngine

type SimpleScript() =
   inherit MonoBehaviour()
   member this.Start() = Debug.Log("F# " + CSharpMath.Add(2, 5).ToString())

type FSharpMath() =
   member this.Add(a, b) = a + b