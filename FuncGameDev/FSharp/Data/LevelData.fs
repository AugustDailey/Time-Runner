module LevelData

type T = { grid: TileData.T[][];
           validTiles: (int*int) list;
           size: int * int; 
           startpos: int * int; 
           stairpos: int * int;
           complete: bool;
           generator: int }