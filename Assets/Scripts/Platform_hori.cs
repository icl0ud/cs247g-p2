using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_hort : MonoBehaviour
{
    public Transform pointA, pointB;
    public float speed;
    public bool moveRight;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collided");
        player.parent = col.transform;
    }
     
    void OnTriggerExit2D()
    {
        player.parent = null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveRight == true) {
            transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);

        } else {
            transform.position -= new Vector3 (speed * Time.deltaTime, 0, 0);
        }

        if (transform.position.x <= pointB.position.x) {
            moveRight = true;
        }

        if (transform.position.x >= pointA.position.x) {
            moveRight = false;
        }
    }
}
