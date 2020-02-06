module GeneratorBehavior

let generate (gs:GameState.T) =
    let generatorBehavior = Map.find GameState.instance.level.generator GeneratorTable.Instance
    generatorBehavior.generate gs