using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BombermanController
{
    // Start is called before the first frame update
    public float playerSpeed;
    public float maxVelocity = 4f;
    private Rigidbody2D _myBody;

    [SerializeField]
    private GameObject boom;
    private Animator anim;
    
    private bool canShoot=true;
    void Awake()
    {
        _myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            if(canShoot)
            {
                StartCoroutine(Shoot());
                //Instantiate(boom, transform.position, Quaternion.identity);
            }
            
        }
    }
    void FixedUpdate()
    {
        PlayerMoveMent();
    }
    void PlayerMoveMent()
    {
        float forxeX = 0f;
        float forxeY = 0f;
        float vel = Mathf.Abs(_myBody.velocity.x);
        float h = Input.GetAxis("Horizontal") ;
        if(h>0)
        {
            if(vel<maxVelocity)
            {
                forxeX = playerSpeed;
                anim.SetBool("Boomber Right", true);
            }
        }
        else if(h<0)
        {
            if(vel<maxVelocity)
            {
                forxeX = -playerSpeed;
                anim.SetBool("Boomber Left", true);
            }
        }
        else
        {
            anim.SetBool("Boomber Right", false);
            anim.SetBool("Boomber Left", false);
        }
        _myBody.AddForce(new Vector2(forxeX, 0));
        //A,D=>-1 0 1=>-1 -0.9 -0.8   0.1
        //-1 0 1
        float v = Input.GetAxis("Vertical") ;
        if(v>0)
        {
            anim.SetBool("Boomber Up", true);
        }
        else if(v<0)
        {
            anim.SetBool("Boomber Down", true);
        }
        else
        {
            anim.SetBool("Boomber Up", false);
            anim.SetBool("Boomber Down", false);
        }
        //W,S=> -1 0 1
        _myBody.velocity = new Vector2(h, v);
    }
    IEnumerator Shoot()
    {
        canShoot = false;
        Instantiate(boom, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1.75f);
        canShoot = true;
    }
}
