module PlayerData

open WeaponData
open ItemData
open EffectData

type PlayerData = { playerid: int; 
                    position: float * float; 
                    health: int; 
                    melee: WeaponData; 
                    ranged: WeaponData; 
                    roll: WeaponData; 
                    active: WeaponData; 
                    items: ItemData list; 
                    effect: EffectData list}