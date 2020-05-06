namespace FSharp.Unity

open UnityEngine
open UnityEngine.SceneManagement

type MainMenuController() =
    inherit MonoBehaviour()

    member this.PlaySinglePlayerGame() =
        "Singleplayer" |> SceneManager.LoadScene

    member this.PlayMultiplayerPlayerGame() =
        "Multiplayer" |> SceneManager.LoadScene

    member this.QuitGame() = 
        "Quitting" |> Debug.Log
        Application.Quit()
