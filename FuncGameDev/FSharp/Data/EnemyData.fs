module EnemyData

type T = { ced: CommonEntityData.T;
           health: int; 
           weapon: WeaponData.T; 
           effects: EffectData.T list }