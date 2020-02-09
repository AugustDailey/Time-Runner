module TestItem

// The Test Item is an item
// When picked up, it increases the timer by 5 seconds
// When dropped, it decreases the time by 5 seconds

let onpickup (item:CommonEntityData.T) (owner:CommonEntityData.T) (gs:GameState.T) =
    { gs with gamedata = { gs.gamedata with time = gs.gamedata.time + 5.0 } }

let ondestroy (item:CommonEntityData.T) (owner:CommonEntityData.T) (gs:GameState.T) =
    { gs with gamedata = { gs.gamedata with time = gs.gamedata.time - 5.0 } }

let spawn xy bid (gs:GameState.T) =
    let itemData = {
        CommonEntityData.id = gs.nextid;
        CommonEntityData.position = xy;
        CommonEntityData.speed = 0.0;
        CommonEntityData.direction = 0.0;
        CommonEntityData.isMoving = false;
        CommonEntityData.data = EntityType.Item {
            ItemData.itemName = "Time";
            ItemData.behaviorID = bid
        }
        CommonEntityData.iframes = 0.0;
        CommonEntityData.sprite = "yay"
    }
    { gs with entities = Map.add gs.nextid itemData gs.entities }

let behavior = {
    ItemBehaviorType.onpickup = onpickup;
    ItemBehaviorType.ondestroy = ondestroy;
    ItemBehaviorType.spawn = spawn;
}
