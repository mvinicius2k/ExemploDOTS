using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[BurstCompile]
public partial struct CarMovementSystem : ISystem
{


    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        if (Input.GetKey(KeyCode.W))
        {
            var deltaTime = SystemAPI.Time.DeltaTime;
            
            foreach (var (carMovement, transform) in SystemAPI.Query<RefRO<CarMovement>, RefRW<LocalTransform>>())
            {
                transform.ValueRW.Rotation = quaternion.LookRotation(carMovement.ValueRO.Direction, math.up());
                transform.ValueRW.Position += carMovement.ValueRO.Speed * deltaTime * carMovement.ValueRO.Direction;
            }

        }

    }


}
