module Destroyer

open UnityEngine

let removeGameObject id =
    let goWrapper = GameObjectWrapper.findWrapperWithID id
    goWrapper.go |> UnityEngine.Object.Destroy
    GameObjectWrapper.removeWrapperWithId id
    ()

let update killIds =
    //Debug.Log(GameState.instance.killIds |> sprintf "%A")
    // destroy all gameobjects with ids matching those in the killIds list
    GameState.instance <- { GameState.instance with killIds = [] }
    killIds |> List.iter removeGameObject
    ()

