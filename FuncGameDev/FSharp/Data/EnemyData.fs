module EnemyData

open WeaponData
open EffectData

type Enemy = { eid: int; 
               position: float * float; 
               health: int; 
               weapon: WeaponData; 
               effects: EffectData list }