module Generator

let generateLevel gs =
    let generatorBehavior = Map.find GameState.instance.level.generator GeneratorTable.Instance
    GameState.instance <- generatorBehavior.generate gs
    ()