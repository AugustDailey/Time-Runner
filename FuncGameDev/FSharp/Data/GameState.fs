module GameState

type T = {
    entities : Collections.Map<int, CommonEntityData.T>; // map from id to entity
    playerPos : (float*float) list // list of player positions
    level: LevelData.T;
    levelParams: LevelParam.T[];
    gamedata: GameData.T;
    nextid: int // the next created entity will have this id
    spawnIds: int list
    killIds: int list
    updateLevel: bool
    random: System.Random
}

let createInitialGameState () =
    {
    entities = Map.empty;
    playerPos = [];
    level = {
        LevelData.grid = [];
        LevelData.validTiles = [];
        LevelData.size = (0,0);
        LevelData.startpos = (0,0);
        LevelData.stairpos = (-14,-7);
        LevelData.complete = false;
        LevelData.generator = 1;
        LevelData.stairsSpawned = true
    };
    levelParams = [||];
    gamedata = {
        GameData.time = 60.0;
        GameData.totaltime = 0.0;
        GameData.floortime = 0.0;
        GameData.floor = 1;
        GameData.highestFloor = 0;
        GameData.highestRemaining = 0.0;
        GameData.lowestTotal = 0.0;
        GameData.camera = { 
            position = (-0.5, -0.5);
            rotation = (0.0, 0.0);
            scale = (1.0, 1.0);
            width = 36.0;
            height = 18.0;
            shakeTime = 0.0;
        }
    };
    nextid = 1
    spawnIds = []
    killIds = []
    updateLevel = false
    random = new System.Random()
}

let mutable instance: T = createInitialGameState ()

