module EnemyData

type T = { health: int; 
           weapon: WeaponData.T; 
           effects: EffectData.T list;
           enemyType: string;
           behaviorId: int;
           aiId: int;
           isBoss: bool }