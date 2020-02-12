module LevelData

type T = { grid: TileData.T[][]
           size: int * int; 
           startpos: int * int; 
           stairpos: int * int;
           complete: bool;
           generator: int }