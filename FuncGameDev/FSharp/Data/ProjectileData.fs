module ProjectileData

type T = { damage: int; 
           effects: EffectData.T list;
           lifespan: float;
           degrees: float; }