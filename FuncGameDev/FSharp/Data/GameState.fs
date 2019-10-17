module GameState

type T = {
    players: PlayerData.T list;
    enemies: EnemyData.T list;
    weapons: WeaponData.T list;
    items: ItemData.T list;
    projectiles: ProjectileData.T list;
    level: LevelData.T;
    gamedata: GameData.T;
    id: int // the next created entity will have this id
}