using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{   // GameMaster Script allows checkpoints to save progress,
    // when player collides with the circle collider of checkpoint,
    // the GameMaster will hold that info for when the player dies.
    // and respawns at the last saved checkpoint.

    private static GameMaster instance;
    // Last Checkpoint save Position.
    public Vector2 lastCheckPointPos;

    void Awake()
    {
        // On load of game, open GameMaster script.
        if(instance == null)
        {
            //Dont destroy on scene change or level reload (e.g. player respawn)
            instance = this;
            DontDestroyOnLoad(instance);
        }
        // auto destroy when play is ended, so multiple GameMasters do not crash game.
        else
        {
            Destroy(gameObject);
        }
    }
}
