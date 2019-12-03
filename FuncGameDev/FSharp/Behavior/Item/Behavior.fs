module ItemBehavior

//activate the item's on-pickup effect
//iid: int = id of the item
//eid: int = id of the entity that picked it up
//gs: GameState = the current gamestate
//returns a function that takes a gamestate and returns a gamestate
let onpickup iid eid (gs:GameState.T) =
    let itemData = GameStateUtils.getEntityByID iid gs
    match itemData.entity with
    | EntityType.Item item ->
        let entityData = GameStateUtils.getEntityByID eid gs
        let itemBehavior = Map.find item.behaviorID ItemBehaviorTable.Instance
        itemBehavior.onpickup itemData entityData gs
    | _ ->
        gs

//activate the item's on-destroy effect
//iid: int = id of the item
//eid: int = id of the entity that picked it up
//gs: GameState = the current gamestate
//returns a function that takes a gamestate and returns a gamestate
let ondestroy iid eid (gs:GameState.T) =
    let itemData = GameStateUtils.getEntityByID iid gs
    match itemData.entity with
    | EntityType.Item item ->
        let entityData = GameStateUtils.getEntityByID eid gs
        let itemBehavior = Map.find item.behaviorID ItemBehaviorTable.Instance
        itemBehavior.ondestroy itemData entityData gs
    | _ ->
        gs