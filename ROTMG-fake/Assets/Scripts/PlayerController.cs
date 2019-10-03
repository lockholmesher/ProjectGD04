using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PersonController
{
    Rigidbody2D rigidbody2d;
    Animator animator;
    Vector2 lookDirection = new Vector2(1,0);
    public int maxHealth = 5;
    public float speed = 3.0f;
    int currentHealth;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
       float vertical = Input.GetAxis("Vertical");
       Vector2 move = new Vector2(horizontal, vertical);

       if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("MoveX", lookDirection.x);
        animator.SetFloat("MoveY", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

       Vector2 position = rigidbody2d.position;
    
       position = position + move * speed * Time.deltaTime;

       rigidbody2d.MovePosition(position);

       if(Input.GetKeyDown(KeyCode.I))
        {
            Launch();
        }
    }

    // void ChangeHealth(int amount)
    // {
    //     currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    //     Debug.Log(currentHealth + "/" + maxHealth);
    // }
    void Launch()
    {
        GameObject projectileObject = Instantiate(bulletPrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        BulletController projectile = projectileObject.GetComponent<BulletController>();
        projectile.Launch(lookDirection, 300);

        animator.SetTrigger("Shoot");
    }
}
