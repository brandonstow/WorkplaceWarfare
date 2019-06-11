using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Allows any object with this script to be picked up by a player when the grab button is held
 * When an object is in range of the player and grab is pressed, the object will parent to the player, this will only happen if the player currently has no held items (children)
 * The object, when it is currently a child of the player, will move to be infront of the player
 * Gravity of the object is disabled whilst it is being held so that it moves with the player
 */

public class Grab : MonoBehaviour
{

    float distance1, distance2, distance3, distance4;
    float maxDistance = 1f;
    public GameObject tempParent1, tempParent2, tempParent3, tempParent4;
    public bool isHolding = false;

    void Update()
    {
        grabPressed(); //Checks if any input from all players

        distance1 = Vector3.Distance(this.transform.position, tempParent1.transform.position); //distance to P1
        distance2 = Vector3.Distance(this.transform.position, tempParent2.transform.position); //distance to P2
        distance3 = Vector3.Distance(this.transform.position, tempParent3.transform.position); //distance to P3
        distance4 = Vector3.Distance(this.transform.position, tempParent4.transform.position); //distance to P4

        if (distance1 >= maxDistance && distance2 >= maxDistance && distance3 >= maxDistance && distance4 >= maxDistance) //If no player is in range of the object, object is dropped
        {
            isHolding = false;
        }

        if (isHolding == true) //Being held
        {
            if (distance1 < distance2 && distance1 < distance3 && distance1 < distance4 && tempParent1.transform.childCount == 0) //If P1 is closer than P2, P3 and P4 the parent to P1
            {
                SoundManager.PlaySound("Grab");
                this.transform.SetParent(tempParent1.transform);
                this.transform.localPosition = Vector3.zero;
            }
            else if (distance2 < distance1 && distance2 < distance3 && distance2 < distance4 && tempParent2.transform.childCount == 0) //If P2 is closer than P1, P3 and P4 then parent to P2
            {
                SoundManager.PlaySound("Grab");
                this.transform.SetParent(tempParent2.transform);
                this.transform.localPosition = Vector3.zero;
            }
            else if (distance3 < distance1 && distance3 < distance2 && distance3 < distance4 && tempParent3.transform.childCount == 0) //If P3 is closer than P1, P2 and P4 then parent to P3
            {
                SoundManager.PlaySound("Grab");
                this.transform.SetParent(tempParent3.transform);
                this.transform.localPosition = Vector3.zero;
            }
            else if (distance4 < distance1 && distance4 < distance2 && distance4 < distance3 && tempParent4.transform.childCount == 0) //If p4 is closer than P1, P2 and P3 then parent to P4
            {
                SoundManager.PlaySound("Grab");
                this.transform.SetParent(tempParent4.transform);
                this.transform.localPosition = Vector3.zero;
            }

        }
        else //Reset to own gravity and space
        {
            this.transform.SetParent(null);
            this.GetComponent<Rigidbody>().useGravity = true;

        }

    }

    void grabPressed() //Checks input from each player
    {
        if (Input.GetButton("grabP1") && (distance1 <= maxDistance))        //If pressed and in range
        {
            isHolding = true;
            this.GetComponent<Rigidbody>().useGravity = false;
            this.GetComponent<Rigidbody>().detectCollisions = true;
        }
        else if (Input.GetButton("grabP2") && (distance2 <= maxDistance))   //If pressed and in range
        {
            isHolding = true;
            this.GetComponent<Rigidbody>().useGravity = false;
            this.GetComponent<Rigidbody>().detectCollisions = true;
        }
        else if (Input.GetButton("grabP3") && (distance3 <= maxDistance))   //If pressed and in range
        {
            isHolding = true;
            this.GetComponent<Rigidbody>().useGravity = false;
            this.GetComponent<Rigidbody>().detectCollisions = true;
        }
        else if (Input.GetButton("grabP4") && (distance4 <= maxDistance))   //If pressed and in range
        {
            isHolding = true;
            this.GetComponent<Rigidbody>().useGravity = false;
            this.GetComponent<Rigidbody>().detectCollisions = true;
        }
        else
        {
            isHolding = false;
        }
    }



}