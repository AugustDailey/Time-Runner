module GeneratorBehavior

let generate (gs:GameState.T) =
    let generatorBehavior = Map.find gs.level.generator GeneratorTable.Instance
    generatorBehavior.generate gs