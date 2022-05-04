using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float startWaitTime = 0.3f;
    private float waitedTime = 0.3f;


    private void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    private void Update()
    {

        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            waitedTime = startWaitTime;
        }
        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if(waitedTime <= 0)
            {
                effector.rotationalOffset = 180f;
                waitedTime = startWaitTime;
            }
            else
            {
                waitedTime -= Time.deltaTime;
            }
        }
        if (Input.GetKey("space") || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            effector.rotationalOffset = 0;
        }
    }
}
