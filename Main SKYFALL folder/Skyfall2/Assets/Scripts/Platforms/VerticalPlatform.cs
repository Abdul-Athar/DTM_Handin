using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;
    private float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the down arrow, or if the S key is pressed.
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            // if keys above are pressed, than wait for 0.1 seconds.
            waitTime = 0.1f;
        }

        // Check if the down arrow, or if the S key is pressed.
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if(waitTime <= 0)
            {
                // player can only enter orange platform from below unless keys above are pressed.
                // change effector to face down and ignore any inputs from above,
                // allows player to fall through platform.
                effector.rotationalOffset = 180f;
                waitTime = 0.1f;
            }else
            {
                waitTime -= Time.deltaTime;
            }
        }
        // if player comes from below and presses the up arrow or W keys
        // than the platform is able to ignore the player and allow him to go through.
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            // the effector is set to facing up by default.
            effector.rotationalOffset = 0;
        }
    }
}
