module CommonEntityData

type T = { id: int;
           direction: float * float;
           speed: float;
           isMoving: bool;
           data: EntityType.T;
           sprite: string }
