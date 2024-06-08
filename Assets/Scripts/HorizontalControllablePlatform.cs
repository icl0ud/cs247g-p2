using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalControllablePlatform : MonoBehaviour
{
    public Transform pointA, pointB;
    public float speed;
    private Transform player;
    private bool moveRight;
    private bool playerOnPlatform;
    private PlayerMovement player_m;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        playerOnPlatform = false;
        player_m = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        if (playerOnPlatform && Input.GetKey(KeyCode.V))
        {
          MovePlatform();
        }
    }

    void MovePlatform()
    {
      moveRight = player_m.isFacingRight;

      if (moveRight == true && transform.position.x < pointA.position.x) {
          transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);
      } else if (moveRight != true && transform.position.x > pointB.position.x) {
          transform.position -= new Vector3 (speed * Time.deltaTime, 0, 0);
      }

    }
    

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform == player)
        {
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
        }
    }
}
