using UnityEngine;

public class CameraScroll : BaseObject
{
    public GameObject target;
    protected override void Update()
    {
        base.Update();
        if(target)
        {   
            if(target.transform.position.y < transform.position.y)
            {
                float more = Mathf.Abs(transform.position.y - target.transform.position.y) / (Screen.height * 0.5f);
                speedRateDrop = Mathf.Clamp(speedRateDrop + more, 0.75f, 1.5f);
            }
            else
            {
                speedRateDrop = 1;
            }
        }
    }
}