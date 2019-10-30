module EntityType

type T =
    | Player of PlayerData.T
    | Enemy of EnemyData.T
    | Item of ItemData.T
    | Weapon of WeaponData.T
    | Projectile of ProjectileData.T