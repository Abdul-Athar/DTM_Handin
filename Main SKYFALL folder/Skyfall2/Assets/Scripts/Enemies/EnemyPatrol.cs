using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;

    // This function makes it easier to make enemies change from right to left,
    // because the same bool is called but changed to false.
    private bool movingRight = true;

    // variables for checking ground and how far away the enemies can check for ground.
    public Transform groundDetection;
    public float distance;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move enemy to the right, at a public speed and change using time (sec).
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        // send a ray infront of the enemy to check for ground.
        // distance can change for diffrent platform types, ray facing down.
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);

        if (groundInfo.collider == false)
        {
            // if the ground cannot be detected than change direction.
            if(movingRight == true)
            {
                // change direction enemy is facing, only changes y axis direction as x and z are 0.
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                // if the enemy is not facing right than when ground ends,
                // than change y direction facing to 0 (facing right).
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
