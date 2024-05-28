using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMask : MonoBehaviour
{
    // Start is called before the first frame update


    public Transform platform;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != platform.position)
        {
            transform.position = platform.position;
        }
    }
}
