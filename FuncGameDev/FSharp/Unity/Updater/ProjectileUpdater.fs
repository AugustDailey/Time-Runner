module ProjectileUpdater

open UnityEngine

let update (entityData:CommonEntityData.T) (projectileData:ProjectileData.T) (gameObject:GameObject) =
    // update projectiles
    let deltaTime = Time.deltaTime |> float
    let newLifespan = projectileData.lifespan - deltaTime
    if newLifespan < 0.0 then 
        entityData.id |> Destroyer.removeGameObject
    else
        ProjectileBehavior.decreaseLifespan entityData.id deltaTime |> Commands.addCommand
        CommonEntityBehavior.move entityData.id entityData.direction |> Commands.addCommand
    ()

