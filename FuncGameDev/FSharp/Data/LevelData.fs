module LevelData

type T = { grid: TileData.T list list;
           validTiles: (int*int) list;
           size: int * int; 
           startpos: int * int; 
           stairpos: int * int;
           complete: bool;
           generator: int;
           stairsSpawned: bool }