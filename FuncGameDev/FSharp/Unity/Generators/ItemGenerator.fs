module ItemGenerator

let r = new System.Random()

type Complex = float * float
    
let checkValidity (locations: Complex list) numItems: Complex list =
    for i in [0..(numItems - 2)] do
        for j in [(i + 1)..(numItems - 1)] do
            while abs (fst locations.[i] - fst locations.[j]) > 5.0 || abs (snd locations.[i] - snd locations.[j]) > 5.0 do
                locations
    locations

let createItemLocations numItems: Complex list =
    let itemLocations = [for i in [1..numItems] -> 
        let randX = (r.NextDouble() - 0.5) * 20.0
        let randY = (r.NextDouble() - 0.5) * 10.0
        (randX, randY)]
    itemLocations

let createItem (location: Complex) = 
    let randX = (r.NextDouble() - 0.5) * 2.0 * 20.0
    let randY = (r.NextDouble() - 0.5) * 2.0 * 10.0
    Spawner.spawnItem (randX, randY) 1
    ()

let generateItems (numItems: int) = 
    let itemLocations = createItemLocations numItems
    let fixedItems = checkValidity itemLocations numItems
    for i in [0..(numItems - 1)] do
        createItem fixedItems.[i]
    ()