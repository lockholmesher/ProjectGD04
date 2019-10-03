using UnityEngine;

public class PlayerController : Player
{
    [Header("Player Controller")]
    public GameObject target;
    public float minDelayShoot;
    
    bool isHold = false;
    float cooldown = 0;

    protected override void Update()
    {
        base.Update();
        HandleInput();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        UpdateJoint();
    }

    void HandleInput()
    {
        if(Input.GetMouseButtonDown(0) && cooldown <= 0)
        {
            isHold = true;
            cooldown = minDelayShoot;
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 offset = mousePosition - (Vector2)transform.position;
            Vector2 direction = offset.normalized;

            RaycastHit2D[] casts = Physics2D.RaycastAll(transform.position, direction);
            foreach(var cast in casts)
            {
                if(cast.collider == null || cast.collider.gameObject == gameObject) continue;

                if(cast.point.y > CameraScreen.MinHeight && cast.point.y < CameraScreen.MaxHeight)
                {
                    target.transform.position = cast.point;
                    distanceJoint.enabled = true;
                }
                    
                SetAnimationHand(cast.point);
                break;
            }
        }
        else if(Input.GetMouseButton(0))
        {
        }
        else if(Input.GetMouseButtonUp(0))
        {
            isHold = false;
        }

        cooldown -= Time.deltaTime;
    }  

    void UpdateJoint()
    {
        if(IsPulled)
        {
            float newDistance = distanceJoint.distance - speedPull * Time.deltaTime;
            if(newDistance < 0)newDistance = 0;
            distanceJoint.distance = newDistance;
        }
    }   

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if(!isHold)
        {
            IdleHand(previousHand);
            distanceJoint.enabled = false;
        } 
    }

    protected override void OnCollisionStay2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if(!isHold)
        {
            IdleHand(previousHand);
            distanceJoint.enabled = false;
        } 
    }

}