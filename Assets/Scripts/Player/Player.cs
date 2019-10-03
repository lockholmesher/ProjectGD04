using UnityEngine;

public class Player : BaseObject
{
    [Header("Player")]
    public float speedPull;
    public float tilt;
    public GameObject face;
    public GameObject leftHand;
    public GameObject rightHand;
    public WebShooter leftShooter;
    public WebShooter rightShooter;
    public float durationRotate;

    protected Hand previousHand;


    protected DistanceJoint2D distanceJoint;

    public bool IsPulled { get{ return distanceJoint.enabled; }}

    protected override void Awake()
    {
        base.Awake();
        distanceJoint = GetComponent<DistanceJoint2D>();
        distanceJoint.enabled = false;
    }

    protected void SetAnimationHand(Vector2 castPoint)
    {
        IdleHand(previousHand);
        float angle = Helper.AngleFromToBy0D(transform.position.x, transform.position.y, castPoint.x, castPoint.y);
        if(castPoint.x < transform.position.x)
        {
            previousHand = Hand.LEFT;
            iTween.RotateTo(face, Vector3.forward * tilt, durationRotate * 0.5f);
            leftHand.transform.localEulerAngles = Vector3.forward * Helper.NormalizeAngle(angle + 180);
            leftShooter.Shoot(castPoint);
        }
        else
        {
            previousHand = Hand.RIGHT;
            iTween.RotateTo(face, Vector3.forward * -tilt, durationRotate * 0.5f);
            rightHand.transform.localEulerAngles = Vector3.forward * Helper.NormalizeAngle(angle);
            rightShooter.Shoot(castPoint);
        }
        
    }

    protected void IdleHand(Hand hand = Hand.NONE)
    {
        if(hand == Hand.LEFT)
        {
            leftShooter.Clear();
            iTween.RotateTo(leftHand, Vector3.zero, durationRotate);
        }

        if(hand == Hand.RIGHT)
        {
            rightShooter.Clear();
            iTween.RotateTo(rightHand, Vector3.zero, durationRotate);
        }

        iTween.RotateTo(face, Vector3.zero, durationRotate);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
    }

    protected virtual void OnCollisionStay2D(Collision2D collision)
    {
    }

}