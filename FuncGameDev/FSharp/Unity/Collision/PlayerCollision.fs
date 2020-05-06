namespace FSharp.Unity.Collision

open UnityEngine

type PlayerCollision()=
    inherit MonoBehaviour()

    member this.OnTriggerEnter2D (col : Collider2D) =
        
        let collisionFunction = match col.gameObject.tag with
            | "Enemy" -> PlayerBehavior.collideWithEnemy
            | "Item" -> PlayerBehavior.collideWithItem
            | "Weapon" -> PlayerBehavior.collideWithWeapon
            | "Projectile" -> PlayerBehavior.collideWithProjectile
            | _ -> PlayerBehavior.collideWithNothing

        match col.gameObject.tag with
            | "Wall" ->
                () // don't try to look up wall in entity list or you'll crash
            | "Stairs" ->
                PlayerBehavior.collideWithStairs |> Commands.addCommand
            | _ ->
                let selfWrapper = GameObjectWrapper.findWrapperForGameObject this.gameObject
                let otherWrapper = GameObjectWrapper.findWrapperForGameObject col.gameObject
                let selfData = GameStateUtils.getEntityByID GameState.instance selfWrapper.id
                let otherData = GameStateUtils.getEntityByID GameState.instance otherWrapper.id
                collisionFunction selfData otherData |> Commands.addCommand
        