using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{
    private GameMaster gm;

    // when something collides with the player.
    void OnTriggerEnter2D(Collider2D other)
    {
        // check if object in contact with player has the projectile tag.
        if (other.CompareTag("Projectile"))
        {
            // if it does that load the scene manager and check for last saved checkpoint.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // When the player is hit with a projectile, or a platform enemy,
        // find the GameMaster object and search for the last saved checkpoint position.
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        // move player to that checkpoint.
        transform.position = gm.lastCheckPointPos;
    }
}
