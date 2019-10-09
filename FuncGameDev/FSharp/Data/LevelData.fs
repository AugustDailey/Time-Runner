module LevelData

type Level = { grid: int list list; 
               size: int * int; 
               startpos: int * int; 
               stairpos: int * int }