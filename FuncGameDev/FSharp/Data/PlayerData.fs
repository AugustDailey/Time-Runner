module PlayerData

type Player = { playerid: String; position: float * float; health: int; melee: Weapon; ranged: Weapon; items: Item array, effect: Effect array}