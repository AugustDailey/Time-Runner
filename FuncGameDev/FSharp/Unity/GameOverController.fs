namespace FSharp.Unity

open UnityEngine
open UnityEngine.SceneManagement
open TMPro

type GameOverController() =
    inherit MonoBehaviour()

    member this.Start() =
        let highestFloor = GameState.instance.gamedata.highestFloor |> string
        let highestRemaining = System.Math.Round (GameState.instance.gamedata.highestRemaining, 3) |> string
        let lowestTotal = System.Math.Round (GameState.instance.gamedata.lowestTotal, 3) |> string
        let txt = this.GetComponentInChildren<TextMeshProUGUI>()
        txt.text <- "Highest Floor: " + highestFloor + "\nHigh Score: " + highestRemaining + "\n Least Time Used: " + lowestTotal
        ()

    member this.BackToMain() =
        "MainMenu" |> SceneManager.LoadScene

    member this.QuitGame() = 
        "Quitting" |> Debug.Log
        Application.Quit()
