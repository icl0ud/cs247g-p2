using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalControllablePlatform : MonoBehaviour
{
    public Transform pointA, pointB;
    public float speed;
    public float fallingRate;
    private Transform player;
    private bool moveUp;
    private bool playerOnPlatform;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        moveUp = false;
        playerOnPlatform = false;
    }

    void Update()
    {
        if (playerOnPlatform)
        {
            if (Input.GetKey(KeyCode.V)) {
                moveUp = true;
            } else {
                moveUp = false;
            }
        }

        MovePlatform();
    }

    void MovePlatform()
    {
      if (moveUp == true && transform.position.y < pointA.position.y) {
          transform.position += new Vector3 (0, speed * Time.deltaTime, 0);
      } else if (moveUp != true && transform.position.y > pointB.position.y) {
          transform.position -= new Vector3 (0, fallingRate * Time.deltaTime, 0);
      }

    }
    

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform == player)
        {
            Debug.Log("Player is on platform!");
            playerOnPlatform = true;
            col.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform == player)
        {
            playerOnPlatform = false;
            col.transform.SetParent(null);
            moveUp = false;
        }
    }
}
