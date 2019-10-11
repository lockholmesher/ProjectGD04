using UnityEngine;

public class ObstacleSpawner : Singleton<ObstacleSpawner>
{
    public float delaySpawn;
    public Pattern[] patternSpawn;
    
    
    int currentIndex = 0;

    void Start()
    {
        StartSpawn();
    }

    public void StartSpawn()
    {
        patternSpawn[currentIndex].Spawn();
    }
}