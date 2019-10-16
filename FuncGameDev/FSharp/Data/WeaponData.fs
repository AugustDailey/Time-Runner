module WeaponData

open EffectData
type WeaponData = { wid: int; 
                cooldown: float; 
                damage: int; 
                effects: EffectData list; 
                weaponType: string}