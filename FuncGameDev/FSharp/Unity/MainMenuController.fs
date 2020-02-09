namespace FSharp.Unity

open UnityEngine
open UnityEngine.SceneManagement

type MainMenuController() =
    inherit MonoBehaviour()

    member this.PlayGame() =
        SceneManager.LoadScene("Gameplay")

    member this.QuitGame() = 
        Debug.Log("Quitting")
        Application.Quit()
