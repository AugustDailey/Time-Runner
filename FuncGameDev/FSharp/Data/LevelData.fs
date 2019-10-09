module LevelData

type Level = { grid: int array2D; size: int * int; startpos: int * int; stairpos: int * int }
    member val grid = [][] with get, set
    member val size = 0, 0 with get, set
    member val startPos = 0, 0 with get, set
    member val stairpos = 0, 0 with get, set