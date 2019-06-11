using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The script is passed a number when dynamite is hit that corresponds to one of the players
 * The player that is hit then has a variable set to their respective number which deducts a point in PauseMenu.cs where the sliders are accessible
 * On collision, the dynamite object is destroyed or if it is not hit after 30 seconds
 */

public class Dynamite : MonoBehaviour {

    public static int dynaPlayerNum;
    private string PlayerID;

	// Use this for initialization
	void Start () 
    {
        StartCoroutine(Timeout());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider player)
    {
        PlayerID = player.tag;

        switch(PlayerID)
        {
            case "Player1":
                dynaPlayerNum = 1;
                break;

            case "Player2":
                dynaPlayerNum = 2;
                break;

            case "Player3":
                dynaPlayerNum = 3;
                break;

            case "Player4":
                dynaPlayerNum = 4;
                break;
        }
        SoundManager.PlaySound("Dynamite");
        Destroy(gameObject);
    }

    IEnumerator Timeout()
    {
        yield return new WaitForSeconds(30f);
        Destroy(gameObject);
    }
}
