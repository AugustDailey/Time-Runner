module ItemBehaviorTable

let Instance : Collections.Map<int, ItemBehaviorType.T> = 
    Map.empty
        .Add(1, TestItem.behavior)