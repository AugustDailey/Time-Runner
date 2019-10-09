module ProjectileData

type Projectile = { projid: int; 
                    position: float * float; 
                    damage: int; 
                    effects: Effect list; 
                    speed: int }