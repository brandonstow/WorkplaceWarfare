using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Labels each room that any player is in by changing the text of their location box
 * If a player is inside the collider that represents a room then it will change to the name set as a string on it
 */

public class ZoneNames : MonoBehaviour
{

    public string zoneName;
    public GameObject ZoneUI1, ZoneUI2, ZoneUI3, ZoneUI4;

    void Start()
    {
        ZoneUI1.SetActive(false);
        ZoneUI2.SetActive(false);
        ZoneUI3.SetActive(false);
        ZoneUI4.SetActive(false);
    }
    
    void OnTriggerEnter(Collider other)
    {
        //Player one enter zone naming
        if(other.gameObject.tag == "Player1")
        {
            ZoneUI1.SetActive(true);
            ZoneUI1.GetComponent<Text>().text = zoneName;
        }
        //Player two enter zone naming
        if (other.gameObject.tag == "Player2")
        {
            ZoneUI2.SetActive(true);
            ZoneUI2.GetComponent<Text>().text = zoneName;
        }
        //Player three enter zone naming
        if (other.gameObject.tag == "Player3")
        {
            ZoneUI3.SetActive(true);
            ZoneUI3.GetComponent<Text>().text = zoneName;
        }
        //Player four enter zone naming
        if (other.gameObject.tag == "Player4")
        {
            ZoneUI4.SetActive(true);
            ZoneUI4.GetComponent<Text>().text = zoneName;
        }
    }

    void OnTriggerExit(Collider other)
    {
        //Player one exit zone naming
        if (other.gameObject.tag == "Player1")
        {
            ZoneUI1.SetActive(false);
        }
        //Player two exit zone naming
        if (other.gameObject.tag == "Player2")
        {
            ZoneUI2.SetActive(false);
        }
        //Player three exit zone naming
        if (other.gameObject.tag == "Player3")
        {
            ZoneUI3.SetActive(false);
        }
        //Player four exit zone naming
        if (other.gameObject.tag == "Player4")
        {
            ZoneUI4.SetActive(false);
        }
    }

}
