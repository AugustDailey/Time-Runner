module GameState

type T = {
    entities : Collections.Map<int, CommonEntityData.T>; // map from id to entity
    level: LevelData.T;
    gamedata: GameData.T;
    nextid: int // the next created entity will have this id
}
