using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Allows the player to place dynamite directly in front of them if dynamite is selected, they have at least one and have pressed triangle whilst not active at a terminal
 */

public class PlaceDynamite : MonoBehaviour {

    public GameObject dynaPre;
    private GameObject Player;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("TriangleP1") && PowerUp.P1Dyna > 0 && PlayerUIs.activePowerup1 == 2 && Interact.preventPowerups1 == false)
        {
            Player = GameObject.FindWithTag("Player1");
            Instantiate(dynaPre, Player.transform.position + (Player.transform.forward * 2), Player.transform.rotation);
            PowerUp.P1Dyna--;
        }

        if (Input.GetButtonDown("TriangleP2") && PowerUp.P2Dyna > 0 && PlayerUIs.activePowerup2 == 2 && Interact.preventPowerups2 == false)
        {
            Player = GameObject.FindWithTag("Player2");
            Instantiate(dynaPre, Player.transform.position + (Player.transform.forward * 2), Player.transform.rotation);
            PowerUp.P2Dyna--;
        }

        if (Input.GetButtonDown("TriangleP3") && PowerUp.P3Dyna > 0 && PlayerUIs.activePowerup3 == 2 && Interact.preventPowerups3 == false)
        {
            Player = GameObject.FindWithTag("Player3");
            Instantiate(dynaPre, Player.transform.position + (Player.transform.forward * 2), Player.transform.rotation);
            PowerUp.P3Dyna--;
        }

        if (Input.GetButtonDown("TriangleP4") && PowerUp.P4Dyna > 0 && PlayerUIs.activePowerup4 == 2 && Interact.preventPowerups4 == false)
        {
            Player = GameObject.FindWithTag("Player4");
            Instantiate(dynaPre, Player.transform.position + (Player.transform.forward * 2), Player.transform.rotation);
            PowerUp.P4Dyna--;
        }
           
	}
}
