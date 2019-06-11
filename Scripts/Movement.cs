using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Controls the movement of each player, meaning only one instance of the script is neccessary
 * Depending on the tag of the player, the inputs will be different, allowing for them to be controlled separately
 * A vector is constantly updated based on the information from the controllers
 */
public class Movement : MonoBehaviour {


    public float moveSpeed;
    public float rotSpeed;
    public bool walking;
 

    void Start()
    {
        moveSpeed = 10f;    //Default speed of all players
        rotSpeed = 20f;     //Rotation speed of all players
  
    }


 
    void Update()
    {
        if (PauseMenu.GameIsPaused == false && PauseMenu.gameStarted == true)
        {
            if (gameObject.tag == "Player1") //Movement of player 1
            {
                Vector3 newPosition = new Vector3(-Input.GetAxis("Horizontal"), 0f, -Input.GetAxis("Vertical"));    //Movement vector
                transform.LookAt(newPosition + transform.position);                                                 //Rotation
                transform.Translate(newPosition * moveSpeed * Time.deltaTime, Space.World);                         //Moves player
            }
            if (gameObject.tag == "Player2") //Movement of player 2
            {
                Vector3 newPosition = new Vector3(-Input.GetAxis("Horizontal2"), 0f, -Input.GetAxis("Vertical2"));
                transform.LookAt(newPosition + transform.position);
                transform.Translate(newPosition * moveSpeed * Time.deltaTime, Space.World);
            }
            if (gameObject.tag == "Player3") //Movement of player 3
            {
                Vector3 newPosition = new Vector3(-Input.GetAxis("Horizontal3"), 0f, -Input.GetAxis("Vertical3"));
                transform.LookAt(newPosition + transform.position);
                transform.Translate(newPosition * moveSpeed * Time.deltaTime, Space.World);
            }
            if (gameObject.tag == "Player4") //Movement of player 4
            {
                Vector3 newPosition = new Vector3(-Input.GetAxis("Horizontal4"), 0f, -Input.GetAxis("Vertical4"));
                transform.LookAt(newPosition + transform.position);
                transform.Translate(newPosition * moveSpeed * Time.deltaTime, Space.World);
            }
        }
        
    }

}
