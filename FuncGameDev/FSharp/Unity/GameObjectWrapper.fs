module GameObjectWrapper

open UnityEngine

type T = { id: int; 
           go: GameObject }

let mutable wrappers: T list = List.empty

let findWrapperWithID id =
    List.find (fun (gow:T) -> gow.id = id) wrappers
    
let findWrapperForGameObject go =
    List.find (fun (gow:T) -> gow.go = go) wrappers

