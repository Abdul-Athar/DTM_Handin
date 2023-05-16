using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameMaster gm;

    // when player triggers collider on checkpoint.
    void OnTriggerEnter2D(Collider2D other)
    {
        // check if object colliding with checkpoint is the player sprite.
        if (other.CompareTag("Player"))
        {
            // find last checkpoint activated from the GameMaster script.
            // transport player to that position when player dies.
            gm.lastCheckPointPos = transform.position;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // find GameMaster object
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }
}
