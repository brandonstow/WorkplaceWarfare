using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Used to display the panels for both maps and tasks
 * 2 instances of this script on the Player group, one for each panel
 * All four players' buttons and panels are in one script
 * 
 * If a player presses their respective panel button, the panel will be visible and active, if no input then it is hidden
 */



public class ShowTasks : MonoBehaviour
{

    public GameObject PanelUI1, PanelUI2, PanelUI3, PanelUI4;
    public string InputP1, InputP2, InputP3, InputP4;
    public bool active, sound;

    void Start()
    {
        PanelUI1.SetActive(false);
        PanelUI2.SetActive(false);
        PanelUI3.SetActive(false);
        PanelUI4.SetActive(false);
        active = false;
    }

    void Update()
    {

        //PLAYER 1
        if (Input.GetButton(InputP1))
        {
            active = true;
        }
        else
        {
            active = false;
        }

        if (active == true)
        {
            PanelUI1.SetActive(true);
        }
        else
        {
            PanelUI1.SetActive(false);
        }

        //PLAYER 2
        if (Input.GetButton(InputP2))
        {
            active = true;
        }
        else
        {
            active = false;
        }

        if (active == true)
        {
            PanelUI2.SetActive(true);
        }
        else
        {
            PanelUI2.SetActive(false);
        }

        //PLAYER 3
        if (Input.GetButton(InputP3))
        {
            active = true;
        }
        else
        {
            active = false;
        }

        if (active == true)
        {
            PanelUI3.SetActive(true);
        }
        else
        {
            PanelUI3.SetActive(false);
        }

        //PLAYER 4
        if (Input.GetButton(InputP4))
        {
            active = true;
        }
        else
        {
            active = false;
        }

        if (active == true)
        {
            PanelUI4.SetActive(true);
        }
        else
        {
            PanelUI4.SetActive(false);
        }

        if (Input.GetButtonDown(InputP1) || Input.GetButtonDown(InputP2) || Input.GetButtonDown(InputP3) || Input.GetButtonDown(InputP4))
        {
            SoundManager.PlaySound("TaskMap");
        }
    }
}
