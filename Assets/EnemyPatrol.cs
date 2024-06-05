using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed;

    private Rigidbody2D rb;
    private Animator anim;
    private Transform destination;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        destination = pointB;
    }

    void Update()
    {
        Vector2 point = destination.position - transform.position;
        if (destination == pointA.transform)
        {
            rb.velocity = new Vector2(-speed, 0);
        } else
        {
            rb.velocity = new Vector2(speed, 0);
        }

        if (Vector2.Distance(transform.position, destination.position) < 0.5f && destination == pointA)
        {
            destination = pointB;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

        if (Vector2.Distance(transform.position, destination.position) < 0.5f && destination == pointB)
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            destination = pointA;
        }
    }
}
