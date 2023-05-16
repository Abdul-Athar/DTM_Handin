using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToTutorial : MonoBehaviour
{
    // newLevel1 can be changed to any scene saved to the scene manager.
    [SerializeField] private string newLevel1;

    // when player hits the green portal, change to next level.
    void OnTriggerEnter2D(Collider2D other)
    {
        // check if object in contact is the player tagged object.
        if (other.CompareTag("Player"))
        {
            // open the scene manager and load the scene labelled with newLevel1
            SceneManager.LoadScene(newLevel1);
        }
    }
}
