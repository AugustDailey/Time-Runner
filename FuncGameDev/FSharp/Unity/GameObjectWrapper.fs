module GameObjectWrapper

open UnityEngine

type T = { id: int; 
           go: GameObject }

let mutable wrappers: Map<int, T> = Map.empty

let findWrapperWithID id =
    Map.find id wrappers
    
let findWrapperForGameObject go =
    let mutable foundGo = { id = -1 ; go = null }
    wrappers |> Map.iter (fun key value ->
        if value.go = go then
            foundGo <- value
        else
            ())
    foundGo

let removeWrapperWithId id =
    wrappers <- Map.remove id wrappers

let addWrapper (wrapper:T) = 
    wrappers <- Map.add wrapper.id wrapper wrappers

