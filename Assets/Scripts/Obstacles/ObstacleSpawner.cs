using System.Collections;
using UnityEngine;

public class ObstacleSpawner : Singleton<ObstacleSpawner>
{
    public float delaySpawn;
    public Pattern[] patternSpawn;
    
    int currentIndex = 0;
    int obstacleSpawned = 0;

    void Start()
    {
        ObstacleObserver.Instance.Add(Define.TOPIC_END_OBSTALCE, OnReceivedOData);

        StartSpawn(true);
    }

    public void StartSpawn(bool isLinear)
    {
        currentIndex = 0;
        if(!isLinear) SpawnPattern();
        else StartCoroutine(_SpawnPattern());
    }

    void SpawnPattern()
    {
        if(currentIndex >= patternSpawn.Length) currentIndex = 0;
        else if(currentIndex < 0) currentIndex = patternSpawn.Length - 1;

        patternSpawn[currentIndex].Spawn();
        obstacleSpawned = patternSpawn[currentIndex].numberSpawned;
        
        currentIndex++;
    }

    IEnumerator _SpawnPattern()
    {
        while(true)
        {
            yield return new WaitForSeconds(delaySpawn);
            SpawnPattern();
        }
    }

    void OnReceivedOData(ObstacleOData data)
    {
        obstacleSpawned--;
        if(obstacleSpawned <= 0)
        {
            // SpawnPattern();
        }
    }
}