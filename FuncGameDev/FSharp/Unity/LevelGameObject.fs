module LevelGameObject

open UnityEngine

let mutable tiles: GameObject[][] = null

let getTileAtPosition x y =
    tiles.[x].[y]