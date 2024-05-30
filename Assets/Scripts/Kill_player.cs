using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill_player : MonoBehaviour
{
    public GameObject player;
    public Transform respawnPoint;
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    //void Update()
    //{
    //    if (player.transform.position.y <= transform.position.y)
    //    {
    //        player.transform.position = respawnPoint.position;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.position = respawnPoint.position;

        }
    }
    
}
