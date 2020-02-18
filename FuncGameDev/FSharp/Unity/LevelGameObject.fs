module LevelGameObject

open UnityEngine

let mutable tiles: GameObject list list = []
let mutable stairs: GameObject = null

let getTileAtPosition x y =
    tiles.[x].[y]