module EnemyData

type T = { health: int; 
           weapon: WeaponData.T; 
           effects: EffectData.T list }