namespace FSharp.Unity

open UnityEngine
open UnityEngine.SceneManagement
open System.Collections.Generic
open TMPro
open System

type MainMenuController() =
    inherit MonoBehaviour()

    member this.PlayGame() =
        "Gameplay" |> SceneManager.LoadScene

    member this.QuitGame() = 
        "Quitting" |> Debug.Log
        Application.Quit()

    