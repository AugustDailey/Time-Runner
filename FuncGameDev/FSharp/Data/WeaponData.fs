module WeaponData

type Category =
    | Melee
    | Ranged
    | Roll
    | Active

type T = { weaponName: string;
           cooldown: float; 
           firerate: float;
           damage: int; 
           effects: EffectData.T list; 
           weaponType: Category;
           behaviorID: int}