module WeaponData

type T = { ced: CommonEntityData.T;
           cooldown: float; 
           damage: int; 
           effects: EffectData.T list; 
           weaponType: string }