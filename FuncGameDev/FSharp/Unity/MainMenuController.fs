namespace FSharp.Unity

open UnityEngine
open UnityEngine.SceneManagement

type MainMenuController() =
    inherit MonoBehaviour()

    member this.PlayGame() =
        "Gameplay" |> SceneManager.LoadScene

    member this.QuitGame() = 
        "Quitting" |> Debug.Log
        Application.Quit()
