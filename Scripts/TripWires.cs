using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * All Trip Wires are placed in-game on every door that can have a Trip Wire
 * By default they are set to hidden but if the player is in range of any Trip Wire, has at least one and presses triangle then the Trip Wire becomes active for 30 seconds
 * If the tripwire is collided with then that player will have points deducted, the code for which is in the PauseMenu script as the sliders are accessible there
 */

public class TripWires : MonoBehaviour {


    public float distP1, distP2, distP3, distP4;
    public GameObject P1, P2, P3, P4;
    float maxDistance = 2.5f;
    private string playerID;
    public static int playerNum;
    private bool active= false;

    // Use this for initialization
    void Start()
    {
        this.GetComponent<Renderer>().enabled = false;
        this.GetComponent<Collider>().enabled = false;
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        distP1 = Vector3.Distance(this.transform.position, P1.transform.position); //distance to Player1
        distP2 = Vector3.Distance(this.transform.position, P2.transform.position); //distance to Player2
        distP3 = Vector3.Distance(this.transform.position, P3.transform.position); //distance to Player3
        distP4 = Vector3.Distance(this.transform.position, P4.transform.position); //distance to Player4

        if (this.GetComponent<Renderer>().enabled == false) //If not currently active
        {
            //If player1 is within range of doorway
            if (Input.GetButtonDown("TriangleP1") && distP1 <= maxDistance && PowerUp.P1Trip > 0 && PlayerUIs.activePowerup1 == 3 && Interact.preventPowerups1 == false)
            {
                this.GetComponent<Renderer>().enabled = true;
                this.GetComponent<Collider>().enabled = true;
                PowerUp.P1Trip--;
                StartCoroutine(TripTime());
                StartCoroutine(TripPlacement());
            }
            //If player2 is within range of doorway
            if (Input.GetButtonDown("TriangleP2") && distP2 <= maxDistance && PowerUp.P2Trip > 0 && PlayerUIs.activePowerup2 == 3 && Interact.preventPowerups2 == false)
            {
                this.GetComponent<Renderer>().enabled = true;
                this.GetComponent<Collider>().enabled = true;
                PowerUp.P2Trip--;
                StartCoroutine(TripTime());
                StartCoroutine(TripPlacement());
            }
            //If player3 is within range of doorway
            if (Input.GetButtonDown("TriangleP3") && distP3 <= maxDistance && PowerUp.P3Trip > 0 && PlayerUIs.activePowerup3 == 3 && Interact.preventPowerups3 == false)
            {
                this.GetComponent<Renderer>().enabled = true;
                this.GetComponent<Collider>().enabled = true;
                PowerUp.P3Trip--;
                StartCoroutine(TripTime());
                StartCoroutine(TripPlacement());
            }
            //If player4 is within range of doorway
            if (Input.GetButtonDown("TriangleP4") && distP4 <= maxDistance && PowerUp.P4Trip > 0 && PlayerUIs.activePowerup4 == 3 && Interact.preventPowerups4 == false)
            {
                this.GetComponent<Renderer>().enabled = true;
                this.GetComponent<Collider>().enabled = true;
                PowerUp.P4Trip--;
                StartCoroutine(TripTime());
                StartCoroutine(TripPlacement());
            }
        }
    }

    IEnumerator TripTime()
    {
        yield return new WaitForSeconds(30f);
        this.GetComponent<Renderer>().enabled = false;
        this.GetComponent<Collider>().enabled = false;
    }

    void OnTriggerEnter(Collider player)
    {
        if (active == true)
        {
            playerID = player.tag;
            SoundManager.PlaySound("Tripwire");
            this.GetComponent<Renderer>().enabled = false;
            this.GetComponent<Collider>().enabled = false;

            switch (playerID) //Goes to switch statement in PauseMenu.cs
            {
                case "Player1":
                    playerNum = 1;
                    break;

                case "Player2":
                    playerNum = 2;
                    break;

                case "Player3":
                    playerNum = 3;
                    break;

                case "player4":
                    playerNum = 4;
                    break;
            }
        }
    }

    IEnumerator TripPlacement()
    {
        yield return new WaitForSeconds(.2f);
        active = true;
    }
}
