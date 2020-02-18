module GeneratorBehavior

let generate (gs:GameState.T) genID =
    let generatorBehavior = Map.find genID GeneratorTable.Instance
    generatorBehavior.generate gs