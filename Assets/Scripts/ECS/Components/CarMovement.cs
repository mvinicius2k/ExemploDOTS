using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct CarMovement : IComponentData
{
    public float3 Direction;
    public float Speed;
}
