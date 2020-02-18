module GeneratorTable

let Instance : Collections.Map<int, GeneratorBehaviorType.T> = 
    Map.empty
        .Add(1, TestGenerator.behavior)
        .Add(2, OpenEasyGenerator.behavior)