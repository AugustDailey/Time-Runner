module EnemyBehaviorTable

let Instance : Collections.Map<int, EnemyBehaviorType.T> = 
    Map.empty
        .Add(1, Stander.behavior)
        .Add(2, Tracker.behavior)