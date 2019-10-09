module EnemyData

type Enemy = { eid: String; position: float * float; health: int; weapon: Weapon; effects: Effect array }