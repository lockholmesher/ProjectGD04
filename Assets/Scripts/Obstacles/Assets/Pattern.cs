using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Pattern/PatternData")]
public class Pattern : ScriptableObject
{
    [System.Serializable]
    public class SpawnPosition
    {
        public ObstacleData obstacle;
        public Vector3 position;
    }

    public SpawnPosition[] obstacles;

    [HideInInspector] public int numberSpawned = 0;

    public void Spawn()
    {
        numberSpawned = 0;
        
        foreach(var obs in obstacles)
        {
            Vector3 position = CameraScreen.GetRealPosition(obs.position, true);
            obs.obstacle.Spawn(position);
            numberSpawned++;
        }
    }
}
