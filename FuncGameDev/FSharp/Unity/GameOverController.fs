namespace FSharp.Unity

open UnityEngine
open UnityEngine.SceneManagement
open TMPro

type GameOverController() =
    inherit MonoBehaviour()

    member this.Start() =
        let highScores = ScoreSavingService.getScores
        let highestFloor = highScores.[0] |> string
        let highestRemaining = highScores.[1] |> string
        let lowestTotal = highScores.[2] |> string
        let txt = this.GetComponentInChildren<TextMeshProUGUI>()
        txt.text <- "Highest Floor: " + highestFloor + "\nHigh Score: " + highestRemaining + "\n Least Time Used: " + lowestTotal
        ()

    member this.PlayAgain() =
        "Gameplay" |> SceneManager.LoadScene

    member this.BackToMain() =
        "MainMenu" |> SceneManager.LoadScene

    member this.QuitGame() = 
        "Quitting" |> Debug.Log
        Application.Quit()
