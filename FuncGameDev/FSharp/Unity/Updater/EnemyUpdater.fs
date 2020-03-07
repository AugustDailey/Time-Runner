module EnemyUpdater

open UnityEngine

let update (entityData:CommonEntityData.T) (enemyData:EnemyData.T) (gameObject:GameObject) =
    // update enemies
    EnemyBehavior.tickWeaponCooldown (Time.deltaTime |> float) entityData.id enemyData.weapon |> Commands.addCommand
    ()

