module GameState

type T = {
    entities : Collections.Map<int, CommonEntityData.T>; // map from id to entity
    level: LevelData.T;
    gamedata: GameData.T;
    nextid: int // the next created entity will have this id
    spawnIds: int list
    killIds: int list
}

let mutable instance: T = {
    entities = Map.empty;
    level = {
        LevelData.grid = Array2D.zeroCreate 0 0;
        LevelData.size = (0,0);
        LevelData.startpos = (0,0);
        LevelData.stairpos = (0,0)
    };
    gamedata = {
        GameData.time = 60.0;
        GameData.floor = 0
    };
    nextid = 1
    spawnIds = []
    killIds = []
}

