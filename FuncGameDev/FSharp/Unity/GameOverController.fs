namespace FSharp.Unity

open UnityEngine
open UnityEngine.SceneManagement
open TMPro

type GameOverController() =
    inherit MonoBehaviour()

    member this.Start() =
        let highestFloor = GameState.instance.gamedata.highestFloor |> string
        let highestRemaining = GameState.instance.gamedata.highestRemaining |> string
        let lowestTotal = GameState.instance.gamedata.lowestTotal |> string
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
