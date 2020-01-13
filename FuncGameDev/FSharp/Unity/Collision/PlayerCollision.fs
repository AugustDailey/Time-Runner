namespace FSharp.Unity.Collision

open UnityEngine

type PlayerCollision()=
    inherit MonoBehaviour()

    member this.Start() = 
        Debug.Log(this.GetComponent<Rigidbody2D>())

    member this.OnTriggerEnter2D (col : Collider2D) =
        
        if (col.gameObject.name = "Player(Clone)") then
            // Player Collision
            Debug.Log("Player collided with another Player")
            ()
        
        if (col.gameObject.name = "Enemy(Clone)") then
            // Enemy Collision
            Debug.Log("Player collided with Enemy")
            ()

        if (col.gameObject.name = "Item(Clone)") then
            // Item Collision
            Debug.Log("Player collided with Item")
            ()

        if (col.gameObject.name = "Weapon(Clone)") then
            // Weapon Collision
            Debug.Log("Player collided with Weapon")
            ()
         
        
        