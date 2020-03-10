namespace FSharp.Unity

open UnityEngine
open UnityEngine.SceneManagement

type PauseMenuController() =
    inherit MonoBehaviour()

    let mutable _isPaused = false

    [<SerializeField>]
    [<DefaultValue>] val mutable _pauseMenu : GameObject

    member this.Start() =
        this._pauseMenu.SetActive(false)
        _isPaused <- false

    member this.Update() =
        if (not _isPaused && Input.GetKeyDown(KeyCode.Escape)) then
            this.Pause()

    member this.Pause() = 
        _isPaused <- true
        this._pauseMenu.SetActive(true)
        Time.timeScale <- 0.0f

    member this.Play() =
        _isPaused <- false
        this._pauseMenu.SetActive(false)
        Time.timeScale <- 1.0f

    member this.Quit() = 
        this.Play()
        "MainMenu" |> SceneManager.LoadScene
