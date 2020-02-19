namespace FSharp.Unity

open UnityEngine
open UnityEngine.SceneManagement
open TMPro

type GameOverController() =
    inherit MonoBehaviour()

    member this.Start() =
        let highScore = ScoreSavingService.getScore
        let txt = this.GetComponentInChildren<TextMeshProUGUI>()
        txt.text <- "High Score: " + (highScore |> string)
        ()

    member this.PlayAgain() =
        "Gameplay" |> SceneManager.LoadScene

    member this.BackToMain() =
        "MainMenu" |> SceneManager.LoadScene

    member this.QuitGame() = 
        "Quitting" |> Debug.Log
        Application.Quit()
