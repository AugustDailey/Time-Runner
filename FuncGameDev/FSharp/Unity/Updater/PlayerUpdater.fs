module PlayerUpdater

open UnityEngine

let update (entityData:CommonEntityData.T) (playerData:PlayerData.T) (gameObject:GameObject) =
    // update player's weapons and stuff
    PlayerBehavior.tickWeaponCooldown (Time.deltaTime |> float) entityData.id playerData.melee |> Commands.addCommand
    PlayerBehavior.tickWeaponCooldown (Time.deltaTime |> float) entityData.id playerData.ranged |> Commands.addCommand
    PlayerBehavior.tickWeaponCooldown (Time.deltaTime |> float) entityData.id playerData.roll |> Commands.addCommand
    PlayerBehavior.tickWeaponCooldown (Time.deltaTime |> float) entityData.id playerData.active |> Commands.addCommand
    ()

let updatePlayerPosHelper (gs:GameState.T) eid (data:CommonEntityData.T) =
    match data.data with
    | EntityType.Player player ->
        { gs with playerPos = List.Cons (data.position, gs.playerPos) }
    | _ ->
        gs

let updatePlayerPos (gs:GameState.T) =
    Map.fold updatePlayerPosHelper { gs with playerPos = [] } gs.entities

