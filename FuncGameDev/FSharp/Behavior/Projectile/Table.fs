module ProjectileBehaviorTable

let Instance : Collections.Map<int, ProjectileBehaviorType.T> = 
    Map.empty
        .Add(1, TestProjectile.behavior)