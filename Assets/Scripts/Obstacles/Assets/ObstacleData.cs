using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Obstacle/ObstacleData")]
public class ObstacleData : ScriptableObject
{
    public Vector3 size;
    public float gravityRate;
    public Obstacle prefab;

    public virtual Obstacle Spawn(Vector3 position)
    {
        Obstacle obs = PoolObjects.Instance.GetFreeObject<Obstacle>(prefab);
        obs.speedRateDrop = gravityRate;
        obs.transform.localScale = size;
        obs.Spawn(position);
        return obs;
    }
}
