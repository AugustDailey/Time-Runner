module InputConfigurationService

open System.IO
open System

let mutable PlayersToControls : Collections.Map<int, ControlModel.T> = Map.ofList[]

let AddControlsToMap (stream : StreamReader) (player : string) =
    let playerNumber = player |> int
    let parsedUp = stream.ReadLine()
    let parsedDown = stream.ReadLine()
    let parsedLeft = stream.ReadLine()
    let parsedRight = stream.ReadLine()
    PlayersToControls.Add(playerNumber, {right = parsedRight; left = parsedLeft; up = parsedUp; down = parsedDown})
    ()

let Read =

    // Read in a file
    use stream = new StreamReader @"C:\Game_Controls.txt"

    // Continue reading while valid lines.
    let valid = true
    while (valid) do
        let line = stream.ReadLine()
        if (line = null) then
            ()
        else
            if (line |> Seq.forall Char.IsDigit)
                then AddControlsToMap stream line
                

    
        
