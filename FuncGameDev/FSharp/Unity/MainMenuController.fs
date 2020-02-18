namespace FSharp.Unity

open UnityEngine
open UnityEngine.SceneManagement
open System.Collections.Generic
open TMPro

type MainMenuController() =
    inherit MonoBehaviour()

    let mutable _keyBindings = new Dictionary<string, KeyCode>()

    [<SerializeField>]
    [<DefaultValue>] val mutable _currentKey : GameObject

    [<SerializeField>]
    [<DefaultValue>] val mutable _up : GameObject

    [<SerializeField>]
    [<DefaultValue>] val mutable _down : GameObject

    [<SerializeField>]
    [<DefaultValue>] val mutable _right : GameObject

    [<SerializeField>]
    [<DefaultValue>] val mutable _left : GameObject

    [<SerializeField>]
    [<DefaultValue>] val mutable _attackM : GameObject

    [<SerializeField>]
    [<DefaultValue>] val mutable _attackR : GameObject

    [<SerializeField>]
    [<DefaultValue>] val mutable _roll : GameObject

    [<SerializeField>]
    [<DefaultValue>] val mutable _menu : GameObject

    member this.Start() =
        _keyBindings.Add("Up", KeyCode.UpArrow)
        _keyBindings.Add("Down", KeyCode.DownArrow)
        _keyBindings.Add("Left", KeyCode.LeftArrow)
        _keyBindings.Add("Right", KeyCode.RightArrow)
        _keyBindings.Add("Attack(Melee)", KeyCode.G)
        _keyBindings.Add("Attack(Range)", KeyCode.F)
        _keyBindings.Add("Roll", KeyCode.R)
        _keyBindings.Add("Menu", KeyCode.Return)

    member this.PlayGame() =
        "Gameplay" |> SceneManager.LoadScene

    member this.QuitGame() = 
        "Quitting" |> Debug.Log
        Application.Quit()

    member this.OnGUI() = 
        let e = Event.current
        if e.isKey then
            Debug.Log("Uh")
            _keyBindings.[this._currentKey.name] <- e.keyCode
            let tm = this._currentKey.GetComponent<TextMeshProUGUI>()
            tm.text <- e.keyCode.ToString()
            this._currentKey <- null
            ()

    member this.ChangeKeyBinding(clicked : GameObject) =
        this._currentKey <- clicked
        ()