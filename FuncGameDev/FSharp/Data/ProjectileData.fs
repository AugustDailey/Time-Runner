module ProjectileData

type T = { ced: CommonEntityData.T;
           damage: int; 
           effects: EffectData.T list; }