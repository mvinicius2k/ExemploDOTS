using Unity.Entities;
using Unity.Mathematics;

public struct CarMovement : IComponentData
{
    public float3 Direction;
    public float Speed;
}
