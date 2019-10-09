module EnemyData

type Enemy = { eid: int; 
               position: float * float; 
               health: int; 
               weapon: WeaponData; 
               effects: Effect list }