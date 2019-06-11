using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * All barricades are placed in-game on every door that can have a barricade
 * By default they are set to hidden but if the player is in range of any barricade, has at least one and presses triangle then the barricade becomes active for 20 seconds
 */

public class DoorBarricades : MonoBehaviour
{

    public float distP1, distP2, distP3, distP4;
    public GameObject P1, P2, P3, P4;
    float maxDistance = 3f;

    // Use this for initialization
    void Start()
    {

        this.GetComponent<Renderer>().enabled = false;
        this.GetComponent<Collider>().enabled = false;
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
            //If player1 is within range
            if (Input.GetButtonDown("TriangleP1") && distP1 <= maxDistance && PowerUp.P1Barric > 0 && PlayerUIs.activePowerup1 == 1 && Interact.preventPowerups1 == false)
            {
                this.GetComponent<Renderer>().enabled = true;
                this.GetComponent<Collider>().enabled = true;
                PowerUp.P1Barric--;
                StartCoroutine(BarricadeTime());
                StartCoroutine(BarrAudio());
            }
            //If player2 is within range
            if (Input.GetButtonDown("TriangleP2") && distP2 <= maxDistance && PowerUp.P2Barric > 0 && PlayerUIs.activePowerup2 == 1 && Interact.preventPowerups2 == false)
            {
                this.GetComponent<Renderer>().enabled = true;
                this.GetComponent<Collider>().enabled = true;
                PowerUp.P2Barric--;
                StartCoroutine(BarricadeTime());
                StartCoroutine(BarrAudio());
            }
            //If player3 is within range
            if (Input.GetButtonDown("TriangleP3") && distP3 <= maxDistance && PowerUp.P3Barric > 0 && PlayerUIs.activePowerup3 == 1 && Interact.preventPowerups3 == false)
            {
                this.GetComponent<Renderer>().enabled = true;
                this.GetComponent<Collider>().enabled = true;
                PowerUp.P3Barric--;
                StartCoroutine(BarricadeTime());
                StartCoroutine(BarrAudio());
            }
            //If player4 is within range
            if (Input.GetButtonDown("TriangleP4") && distP4 <= maxDistance && PowerUp.P4Barric > 0 && PlayerUIs.activePowerup4 == 1 && Interact.preventPowerups4 == false) 
            {
                this.GetComponent<Renderer>().enabled = true;
                this.GetComponent<Collider>().enabled = true;
                PowerUp.P4Barric--;
                StartCoroutine(BarricadeTime());
                StartCoroutine(BarrAudio());

            }
        }
    }

    IEnumerator BarricadeTime()
    {
        yield return new WaitForSeconds(20f);
        this.GetComponent<Renderer>().enabled = false;
        this.GetComponent<Collider>().enabled = false;
    }

    IEnumerator BarrAudio()
    {
        SoundManager.PlaySound("Barricade");
        yield return new WaitForSeconds(.2f);
        SoundManager.PlaySound("Barricade");
    }
}
