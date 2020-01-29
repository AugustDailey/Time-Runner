module Commands

let mutable commands : (GameState.T -> GameState.T) list = []

let addCommand x = 
    commands <- x::commands

let executeAllCommands (gs:GameState.T) = 
    match List.length commands with
    | 0 -> 
        gs
    | _ ->
        let grandCommand = List.reduce (<<) commands // Compose all functions in the command list into one superfunction
        let newGs = grandCommand gs // Run the grand command on our gamestate to get the output gamestate, and return it
        commands <- []
        newGs
    


