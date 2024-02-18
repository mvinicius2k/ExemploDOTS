using Unity.Entities;
using UnityEngine;


public class CarMovementAuthoring : MonoBehaviour
{
    public float Speed;
    public Vector3 Direction;
}

public class CarMovementBaker : Baker<CarMovementAuthoring>
{
    public override void Bake(CarMovementAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);

        AddComponent(entity, new CarMovement
        {
            Direction = authoring.Direction.normalized,
            Speed = authoring.Speed,
        });
    }
}
