module CommonEntityUpdater

open UnityEngine

let updateGameStateEntity (gs:GameState.T) id (wrapper:GameObjectWrapper.T) =
    let entity = GameStateUtils.getEntityByID gs id
    let transform = wrapper.go.transform.position
    let newPos = (transform.x |> float, transform.y |> float)
    let iframes = Mathf.Max(((entity.iframes |> float32) - Time.deltaTime), 0.0f) |> float
    let fixedEntity = { entity with isMoving = false ; position = newPos ; iframes = iframes }
    { gs with entities = Map.add id fixedEntity gs.entities }

let updateGameStateEntities (gs:GameState.T) (goWrappers:Map<int, GameObjectWrapper.T>) =
    goWrappers |> Map.fold updateGameStateEntity gs

let update (entityData:CommonEntityData.T) (gameObject:GameObject) =
    let anim = gameObject.GetComponent<Animator>()
    anim.SetBool("isMoving", entityData.isMoving)
    let dir_int = entityData.direction |> int
    let direction = ((dir_int % 360) + 360) % 360
    anim.SetFloat("direction", direction |> float32)
    match entityData.isMoving with
    | true ->
        let x = entityData.position |> fst |> float32
        let y = entityData.position |> snd |> float32
        let angle = (entityData.direction |> float32) * Mathf.Deg2Rad
        let direction = new Vector3(angle |> Mathf.Cos, angle |> Mathf.Sin, 0.0f)
        let step = (entityData.speed |> float32) * Time.deltaTime
        gameObject.transform.Translate(direction * step)
    | false ->
        ()

