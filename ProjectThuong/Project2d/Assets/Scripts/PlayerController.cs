using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlaneController
{
    public float speed = 50f,maxspeed = 3, jumpPow = 200f;
    public bool grounded = true, faceright = true;
    public Rigidbody2D r2;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded",grounded);
        anim.SetFloat("speed",Mathf.Abs(r2.velocity.x));
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false; 
                r2.AddForce(Vector2.up * jumpPow);
            }
            
        }

    }
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        r2.AddForce((Vector2.right) *speed * h);
//gioi han toc do

        if(r2.velocity.x > maxspeed)
        r2.velocity = new Vector2(maxspeed,r2.position.y);
        if(r2.velocity.x < -maxspeed)
        r2.velocity = new Vector2(maxspeed,r2.position.y);
        
        if(h>0 && !faceright)
        {
            Flip();
        }
        if(h< 0 && !faceright)
        {
            Flip();
        }
    }
    public void Flip()
    {
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;


    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
