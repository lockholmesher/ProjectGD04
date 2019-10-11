using UnityEngine;


public class Obstacle : BaseObject
{
    public virtual void Spawn(Vector3 position)
    {
    }

    public virtual void End()
    {
        ObstacleObserver.Instance.Notify(Define.TOPIC_END_OBSTALCE, new ObstacleOData());
        gameObject.SetActive(false);
    }
}