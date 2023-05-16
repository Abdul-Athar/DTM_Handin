using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShot : MonoBehaviour
{
    public float speed;

    // move projectile
    private Transform player;

    // find target
    private Vector2 target;

    // how long projectile lasts before destroyed.
    public float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        // find object with the Player tag
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // destroy projectile if lifetime is reached in seconds.
        Destroy(gameObject, lifeTime);

        // find last known position of player every time the shooting enemy fires.
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        // move projectile towards last known position of the target at a public speed and time.
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // when the projectile reaches last known target position AND player is not hit, destroy itself.
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    // if player collides with the projectile, destroy the projectile.
    //(Player will die in another script, this is only for the projectile.)
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
        }
    }

    // Defining DestroyProjectile. easier to call than saying to destroy game object every time.
    void DestroyProjectile()
        {
            Destroy(gameObject);
        }
}
