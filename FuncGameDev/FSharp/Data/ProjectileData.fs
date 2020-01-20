module ProjectileData

type T = { damage: int; 
           effects: EffectData.T list;
           lifespan: float;
           degrees: float; 
           behaviorID: int;
           health: int; // number of things it can hit before it dies
           team: int } // 0 is friendly, 1 is enemy, 2+ can damage anyone