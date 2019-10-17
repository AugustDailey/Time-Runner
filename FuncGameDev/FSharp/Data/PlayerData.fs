module PlayerData

type T = { ced: CommonEntityData.T;
           melee: WeaponData.T; 
           ranged: WeaponData.T; 
           roll: WeaponData.T; 
           active: WeaponData.T; 
           items: ItemData.T list; 
           effects: EffectData.T list }