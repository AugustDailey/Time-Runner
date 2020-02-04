namespace FSharp.Unity.Collision

open UnityEngine

type PlayerCollision()=
    inherit MonoBehaviour()

    member this.OnTriggerEnter2D (col : Collider2D) =
        
        let collisionFunction = match col.gameObject.tag with
            | "Player" -> PlayerBehavior.collideWithPlayer
            | "Enemy" -> PlayerBehavior.collideWithEnemy
            | "Item" -> PlayerBehavior.collideWithItem
            | "Weapon" -> PlayerBehavior.collideWithWeapon
            | "Projectile" -> PlayerBehavior.collideWithProjectile

        let selfWrapper = GameObjectWrapper.findWrapperForGameObject this.gameObject
        let otherWrapper = GameObjectWrapper.findWrapperForGameObject col.gameObject
        let selfData = GameStateUtils.getEntityByID GameState.instance selfWrapper.id
        let otherData = GameStateUtils.getEntityByID GameState.instance otherWrapper.id
        collisionFunction selfData otherData |> Commands.addCommand
        