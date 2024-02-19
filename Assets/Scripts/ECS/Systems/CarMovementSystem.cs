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

            new CarMovementJob
            {
                DeltaTime = deltaTime
            }.ScheduleParallel();

        }

    }

}

public partial struct CarMovementJob : IJobEntity
{
    public float DeltaTime;

    void Execute(in CarMovement carMovement, ref LocalTransform localTransform)
    {
        localTransform.Rotation = quaternion.LookRotation(carMovement.Direction, math.up());
        localTransform.Position += carMovement.Speed * DeltaTime * carMovement.Direction;
    }
}
