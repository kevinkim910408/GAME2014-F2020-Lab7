using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpossumBehaviour : MonoBehaviour
{
    public float runSpeed;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidbody2D;
    public Transform lookAheadPoint;
    public LayerMask layerMask;
    public float direction;

    public bool isGroundedAhead;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        isGroundedAhead = false;
        direction = 1.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LookAhead();
        Move();
    }

    private void LookAhead()
    {
        // Line Cast - begin and end point
        isGroundedAhead = Physics2D.Linecast(transform.position, lookAheadPoint.position, layerMask);
        
        Debug.DrawLine(transform.position, lookAheadPoint.position, Color.green);
    }

    private void Move()
    {
        if (isGroundedAhead)
        {
            rigidbody2D.AddForce(Vector2.left * runSpeed * Time.deltaTime * direction);

        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z) ;
            direction *= -1.0f;
        }

        rigidbody2D.velocity *= 0.90f;
    }

}
