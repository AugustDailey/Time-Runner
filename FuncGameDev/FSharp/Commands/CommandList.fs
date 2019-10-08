module Commands

let mutable commands = [1; 2; 3]

let addCommand x = 
    commands <- x::commands

let executeAllCommands commands = 
    //List.iter (fun x -> execute x) commands
    List.iter (fun x -> printfn "Executing element %d" x) commands

addCommand 4
addCommand 5
executeAllCommands commands;;

//printfn "%A" commands;;
