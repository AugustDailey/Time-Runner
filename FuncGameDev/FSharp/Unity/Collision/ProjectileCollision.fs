namespace FSharp.Unity.Collision

open UnityEngine

type ProjectileCollision()=
    inherit MonoBehaviour()

    member this.OnTriggerEnter2D (col : Collider2D) =
        ()
        let collisionFunction = match col.gameObject.tag with
            | "Player" -> ProjectileBehavior.collideWithPlayer
            | "Enemy" -> ProjectileBehavior.collideWithEnemy
            | _ -> PlayerBehavior.collideWithNothing

        match col.gameObject.tag with
            | "Wall" ->
                let selfWrapper = GameObjectWrapper.findWrapperForGameObject this.gameObject
                let selfData = GameStateUtils.getEntityByID GameState.instance selfWrapper.id
                ProjectileBehavior.collideWithWall selfData |> Commands.addCommand // don't try to look up wall in entity list or you'll crash
            | "Stairs" ->
                ()
            | _ ->
                ()
                let selfWrapper = GameObjectWrapper.findWrapperForGameObject this.gameObject
                let otherWrapper = GameObjectWrapper.findWrapperForGameObject col.gameObject
                let selfData = GameStateUtils.getEntityByID GameState.instance selfWrapper.id
                let otherData = GameStateUtils.getEntityByID GameState.instance otherWrapper.id
                collisionFunction selfData otherData |> Commands.addCommand
        