module ItemBehavior

// activate on-pickup effect of item
// with id = id
// on player with id = pid
let onPickup id pid gs = 
    gs;

// activate on-destroy effect of item
// with id = id
// on player with id = pid
let onDestroy id pid gs =
    gs;

let move = CommonEntityBehavior.move;
let collides = CommonEntityBehavior.collides;
let die = CommonEntityBehavior.die;