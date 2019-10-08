module Commands

let mutable commands = [1; 2; 3]

let addCommand x = 
    commands <- x::commands

let executeAllCommands commands = 
    // Looping through list to execute commands and ignoring subsequent output list
    List.map (fun x -> printfn "Executing element %d" x) commands |> ignore

addCommand 4
addCommand 5
executeAllCommands commands;;