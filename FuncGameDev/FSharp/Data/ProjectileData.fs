module ProjectileData

type Projectile = { projid: String; position: float * float; damage: int; effects: Effect array; speed: int }
    member val pid = "" with get, set
    member val position = 0.0, 0.0 with get, set
    member val damage = 0 with get, set
    member val effects = [] with get, set
    member val speed = 0 with get, set