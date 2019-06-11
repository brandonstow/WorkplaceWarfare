using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Each powerup is contained in this script with the possibility to add more to the randomiser by increasing the random range and adding to the switch statement
 * Holds variables for the number of power ups each player has - Barricades, Trip Wires or Dynamite
 * 
 * At the start of each game, each power up is randomised. Then when the player collects it, this number determines the effect it has on the player
 * The power ups display after a randomised time, then are visible for 30 seconds before disappearing if not collected and the process repeats
 * For powerups that are placeable items, the player's id is checked to assign it to the correct person
 */

public class PowerUp : MonoBehaviour {

    public static int P1Barric, P2Barric, P3Barric, P4Barric, P1Dyna, P2Dyna, P3Dyna, P4Dyna,
        P1Trip, P2Trip, P3Trip, P4Trip;
    float powerupTimer = 15f, multiplier = 1.5f;
    string playerID;
    int randItem, randTime, caseNum;
    bool restartPowerup = true;
    public static int pointPowerUp = 0;
    public GameObject pickupEffect;

    void Start()
    {
        randItem = Random.Range(1, 8); //Chooses power up between 1 and 7
        //randItem = 7; //Use to test specific power up
    }

    void Update()
    {
        transform.Rotate(0, 2, 0, Space.World); //Rotates powerup

        if (restartPowerup == true) //Loops coroutine
        {
            StartCoroutine(ShowPowerup());
        }
    }

    public void OnTriggerEnter(Collider player) //Activates power up on collision depending on what it does
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        Debug.Log(randItem);

        if (randItem != 5) //Plays pick up sound unless it is a point pickup to prevent sounds clashing
        {
            SoundManager.PlaySound("Pickup");
        }

            switch (randItem)
        {
            case 1: //Barricade
                hidePowerup();
                playerID = player.tag;
                caseNum = 1;
                playerCheck();
                break;


            case 2: //Bear Trap
                StartCoroutine(Beartrap(player));
                break;


            case 3: //Speed Up
                StartCoroutine(Speedup(player));
                break;
            

            case 4: //Slow Down
                StartCoroutine(Slowdown(player));
                break;


            case 5: //Point
                hidePowerup();
                playerID = player.tag;
                caseNum = 5;
                playerCheck();
                SoundManager.PlaySound("Point");
                break;

            case 6: //Dynamite
                hidePowerup();
                playerID = player.tag;
                caseNum = 6;
                playerCheck();
                break;

            case 7: //Trip Wire
                hidePowerup();
                playerID = player.tag;
                caseNum = 7;
                playerCheck();
                break;

        }
            Destroy(pickupEffect);
    }

    void playerCheck() //Checks which player collected the power up. Checks the case number from above and acts accordingly
    {
        if (playerID == "Player1")
        {
            switch (caseNum)
            {
                case 1:
                    P1Barric++;
                    break;
                case 5:
                    pointPowerUp = 1;
                    break;
                case 6:
                    P1Dyna++;
                    break;
                case 7:
                    P1Trip++;
                    break;
            }
        }

        if (playerID == "Player2")
        {
            switch (caseNum)
            {
                case 1:
                    P2Barric++;
                    break;
                case 5:
                    pointPowerUp = 2;
                    break;
                case 6:
                    P2Dyna++;
                    break;
                case 7:
                    P2Trip++;
                    break;
            }
        }

        if (playerID == "Player3")
        {
            switch (caseNum)
            {
                case 1:
                    P3Barric++;
                    break;
                case 5:
                    pointPowerUp = 3;
                    break;
                case 6:
                    P3Dyna++;
                    break;
                case 7:
                    P3Trip++;
                    break;
            }
        }

        if (playerID == "Player4")
        {
            switch (caseNum)
            {
                case 1:
                    P4Barric++;
                    break;
                case 5:
                    pointPowerUp = 4;
                    break;
                case 6:
                    P4Dyna++;
                    break;
                case 7:
                    P4Trip++;
                    break;
            }
        }

    }

    IEnumerator ShowPowerup() //Starts timer till powerup is collectable, hides if not collected, loops.
    {
        restartPowerup = false;
        hidePowerup();
        randTime = Random.Range(10, 180);
        yield return new WaitForSeconds(randTime);
        ViewPowerUp();
        yield return new WaitForSeconds(powerupTimer);
        restartPowerup = true;
    }

    void hidePowerup() //Makes power up and icons invisible
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        
    }

    void ViewPowerUp() //Shows powerup, enables visibility and icons
    {
        SoundManager.PlaySound("PowerUp");
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<Collider>().enabled = true;
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(true);

    }

    IEnumerator Beartrap(Collider player) //Player is imobilised for a period of time
    {
        Movement speed = player.GetComponent<Movement>();
        speed.moveSpeed = 0;
        hidePowerup();
        yield return new WaitForSeconds(5f);
        speed.moveSpeed = 10;
    }

    IEnumerator Speedup(Collider player) //Player speeds up for a period of time
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        Movement speed = player.GetComponent<Movement>();
        speed.moveSpeed *= multiplier;
        hidePowerup();
        yield return new WaitForSeconds(5f);
        speed.moveSpeed /= multiplier;
        Destroy(pickupEffect);
    }

    IEnumerator Slowdown(Collider player) //Player slows down for a period of time
    {
        Movement speed = player.GetComponent<Movement>();
        speed.moveSpeed /= multiplier;
        hidePowerup();
        yield return new WaitForSeconds(5f);
        speed.moveSpeed *= multiplier;
    }

}
