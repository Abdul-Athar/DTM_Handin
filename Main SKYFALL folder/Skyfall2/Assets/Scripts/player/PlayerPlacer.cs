using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlacer : MonoBehaviour
{
    // Sometimes the player does not spawn at the right position,
    // this script finds the player when play is pressed and moves
    // him to the exact postion the game level is supposed to start at.
    [SerializeField] private Vector3 startPos;

    private void Awake()
    {
        // find object with player tag
        GameObject player = GameObject.FindWithTag("Player");

        // move player to starting position
        player.transform.position = startPos;
    }

}
