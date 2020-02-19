module ProjectileBehaviorTable

let Instance : Collections.Map<int, ProjectileBehaviorType.T> = 
    Map.empty
        .Add(1, RangedProjectile.behavior)
        .Add(2, MeleeProjectile.behavior)