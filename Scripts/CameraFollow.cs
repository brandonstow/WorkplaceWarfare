using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Smoothes out movement of the camera following the player and ensures it stays facing the player at the same angle no matter what direction the player turns
 */

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

    void Start() 
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
