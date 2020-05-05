module ProjectileUpdater

open UnityEngine

let update (entityData:CommonEntityData.T) (projectileData:ProjectileData.T) (gameObject:GameObject) =
    // update projectiles
    let deltaTime = Time.deltaTime |> float
    let direction = 0.0f |> float
    // need to move these just straight forward due to transform.rotate for the sprite
    ProjectileBehavior.decreaseLifespan entityData.id deltaTime |> Commands.addCommand
    CommonEntityBehavior.move entityData.id direction |> Commands.addCommand
