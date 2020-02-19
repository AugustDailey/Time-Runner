module ProjectileUpdater

open UnityEngine

let update (entityData:CommonEntityData.T) (projectileData:ProjectileData.T) (gameObject:GameObject) =
    // update projectiles
    let deltaTime = Time.deltaTime |> float
    ProjectileBehavior.decreaseLifespan entityData.id deltaTime |> Commands.addCommand
    CommonEntityBehavior.move entityData.id entityData.direction |> Commands.addCommand
