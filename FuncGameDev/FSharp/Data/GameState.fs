module GameState

type T = {
    entities : Collections.Map<int, CommonEntityData.T>; // map from id to entity
    level: LevelData.T;
    gamedata: GameData.T;
    nextid: int // the next created entity will have this id
    spawnIds: int list
    killIds: int list
    updateLevel: bool
}

let mutable instance: T = {
    entities = Map.empty;
    level = {
        LevelData.grid = null;
        LevelData.size = (0,0);
        LevelData.startpos = (0,0);
        LevelData.stairpos = (0,0);
        LevelData.generator = 1
    };
    gamedata = {
        GameData.time = 60.0;
        GameData.floor = 0
        GameData.camera = { 
            position = (0.0, 0.0);
            rotation = (0.0, 0.0);
            scale = (1.0, 1.0);
            width = 20.0;
            height = 10.0;
        }
    };
    nextid = 1
    spawnIds = []
    killIds = []
    updateLevel = false
}

