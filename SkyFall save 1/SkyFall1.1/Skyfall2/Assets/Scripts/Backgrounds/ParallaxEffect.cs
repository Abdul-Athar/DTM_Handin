using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    // parallax effect makes the backgrounds move at diffrent speeds,
    // e.g. Background will move faster than the foreground.

    public Camera cam;
    public Transform followTarget;

    // starting general position of the parallax game object.
    // (this makes the effect start from the same place every time)
    Vector2 startingPosition;

    //Starting exact Z value of each background.
    //(this changes speed of each background)
    float startingZ;

    // Distance that the camera has moved from the starting position of the prllx object.
    Vector2 camMoveSinceStart => (Vector2) cam.transform.position - startingPosition;

    float zDistanceFromTarget => transform.position.z - followTarget.transform.position.z;

    float clippingPlane => (cam.transform.position.z + (zDistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));
    
    // The further the object from player the faster the effect will move.
    // The closer Z value to player the slower it will move.
    float parallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        startingZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        // When the target moves, move the parallax object the same distance times a multiplier
        Vector2 newPosition = startingPosition + camMoveSinceStart * parallaxFactor;

        // The X/Y position changes based on target travel speed times the parallax factor,
        // but the z will stay consistant.
        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
    }
}
