namespace FSharp.Unity.Collision

open UnityEngine

type PlayerCollision()=
    inherit MonoBehaviour()

    member this.OnTriggerEnter2D (col : Collider2D) =
        
        let collisionFunction = match col.gameObject.name with
            | "Player(Clone)" -> PlayerBehavior.collideWithPlayer
            | "Enemy(Clone)" -> PlayerBehavior.collideWithEnemy
            | "Item(Clone)" -> PlayerBehavior.collideWithItem
            | "Weapon(Clone)" -> PlayerBehavior.collideWithWeapon
            | "Projectile(Clone)" -> PlayerBehavior.collideWithProjectile

        let selfWrapper = GameObjectWrapper.findWrapperForGameObject this.gameObject
        let otherWrapper = GameObjectWrapper.findWrapperForGameObject col.gameObject
        let selfData = GameStateUtils.getEntityByID GameState.instance selfWrapper.id
        let otherData = GameStateUtils.getEntityByID GameState.instance otherWrapper.id
        collisionFunction selfData otherData |> Commands.addCommand
        