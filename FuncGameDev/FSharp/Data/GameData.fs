module GameData

// Highest floor, remaining time, and lowest total time are stored here because writing to the file takes a longer time than loading a new scene
// This eliminates the need to wait for the high scores to write to the file before loading game over and not loading the most recent scores

type T = { time: float;
           totaltime: float;
           floortime: float;
           floor: int;
           highestFloor: int;
           highestRemaining: float;
           lowestTotal: float;
           camera: CameraData.T }