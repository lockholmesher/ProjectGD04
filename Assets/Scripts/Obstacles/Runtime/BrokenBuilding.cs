using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenBuilding : Obstacle
{
    BoxCollider2D box;

    protected override void Awake()
    {
        base.Awake();
        box = GetComponent<BoxCollider2D>();
    }

    public override void Spawn(Vector3 position)
    {
        transform.position = position;
    }

    protected override void Update()
    {
        base.Update();
        if(transform.position.y > CameraScreen.MaxHeight + box.size.y * 0.5f)
        {
            End(); 
        }
    }
}
