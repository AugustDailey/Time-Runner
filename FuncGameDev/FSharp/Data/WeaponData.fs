module WeaponData

type Weapon = { wid: int; 
                cooldown: float; 
                damage: 0; 
                effects: Effect list; 
                weaponType: String}