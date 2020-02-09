module CommonEntityData

type T = { id: int;
           position: float * float;
           speed: float;
           direction: float;
           isMoving: bool;
           data: EntityType.T;
           iframes: float;
           sprite: string }
