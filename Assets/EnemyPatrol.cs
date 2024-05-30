using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    public bool MoveRight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveRight = true;
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (MoveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
        }
    }
}
