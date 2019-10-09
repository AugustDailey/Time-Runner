module PlayerBehavior

//Use equipped weapon
//pid: int = id of player (1-4)
//weapontype: WeaponType = category of weapon to use
//gs: GameState = the current gamestate
//returns a function that takes a gamestate and returns a gamestate
let useWeapon pid weapontype gs =
    gs