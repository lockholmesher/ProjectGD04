using UnityEngine;

public class CameraScroll : BaseObject
{
    public GameObject target;
    public float speedChange;
    public Range rangeRateDrop;
    
    float targetRate = 1;

    void Start()
    {
        targetRate = speedRateDrop;
    }

    protected override void Update()
    {
        base.Update();
        
        if(targetRate < speedRateDrop)
            speedRateDrop = Mathf.Clamp(speedRateDrop - speedChange * Time.deltaTime, rangeRateDrop.min, rangeRateDrop.max);
        else if(targetRate > speedRateDrop)
            speedRateDrop = Mathf.Clamp(speedRateDrop + speedChange * Time.deltaTime, rangeRateDrop.min, rangeRateDrop.max);

        if(target)
        {   
            if(target.transform.position.y < transform.position.y)
            {
                float more = Mathf.Abs(transform.position.y - target.transform.position.y) / (Screen.height * 0.5f);
                targetRate = rangeRateDrop.max;
            }
            else
            {
                targetRate = 1;
            }
        }
    }
}