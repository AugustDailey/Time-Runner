module WeaponBehaviorType

type T = {

    //A function that takes in the following:
    //  a WeaponData instance, which is the weapon being used
    //  a CommonEntityData, which is the owner of the weapon
    //  a float*float, which is the xy position of the unit using the weapon
    //  a float, which is the degree direction the unit is facing
    //  a GameState instance
    //They return a GameState instance

    attack: (WeaponData.T -> CommonEntityData.T -> float*float -> float -> GameState.T -> GameState.T)
    spawn: ((float * float) -> GameState.T -> GameState.T)
    createWeapon: unit -> WeaponData.T
}