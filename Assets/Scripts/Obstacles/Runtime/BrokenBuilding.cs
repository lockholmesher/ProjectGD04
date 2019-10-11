using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenBuilding : Obstacle
{
    public override void Spawn(Vector3 position)
    {
        transform.position = position;
    }
}
