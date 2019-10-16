module ProjectileData

open EffectData

type Projectile = { projid: int; 
                    position: float * float; 
                    damage: int; 
                    effects: EffectData list; 
                    speed: int }