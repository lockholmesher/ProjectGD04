using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class BaseObject : MonoBehaviour
{
    [Header("Base Object")]
    public float speedRateDrop = 1;

    new Rigidbody2D rigidbody;

    protected virtual void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        // transform.Translate(Game.Gravity * Time.deltaTime * speedRateDrop);
    }

    protected virtual void FixedUpdate()
    {
        Vector2 newPosition = rigidbody.position + Game.Gravity * Time.deltaTime * speedRateDrop;
        rigidbody.MovePosition(newPosition);
    }
}
