module CommonEntityUpdater

open UnityEngine

let update (entityData:CommonEntityData.T) (gameObject:GameObject) =
    //let x = entityData.position |> fst |> float32
    //let y = entityData.position |> snd |> float32


    //let pos = gameObject.transform.position
    //let newPos = new Vector3(x, y)
    //let dir = (newPos - pos).normalized
    //let distance = Vector3.Distance(pos, newPos)
    //let movement = distance * dir
    //let movement2 = new Vector2(movement.x, movement.y)
    //gameObject.GetComponent<Rigidbody2D>().MovePosition(movement)
    let rigidB = gameObject.GetComponent<Rigidbody2D>()
    //rigidB.velocity = new Vector2((fst entityData.direction)*entityData.speed |> float32, (snd entityData.direction)*entityData.speed |> float32)
    
    
    gameObject.transform.position = gameObject.transform.position + new Vector3((fst entityData.direction)*entityData.speed |> float32, (snd entityData.direction)*entityData.speed |> float32)
    ()

