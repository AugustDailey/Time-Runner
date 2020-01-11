module PlayerData

type T = { melee: WeaponData.T; 
           ranged: WeaponData.T; 
           roll: WeaponData.T; 
           active: WeaponData.T; 
           items: ItemData.T list; 
           effects: EffectData.T list;
           controlModel: ControlModel.T }