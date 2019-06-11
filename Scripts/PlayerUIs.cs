using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Controls the item boxes for each player and the text inside them
 * Also controls the selection of each player's item and the item name whenever a different item is selected
 */

public class PlayerUIs : MonoBehaviour
{

    public GameObject P1Item, P2Item, P3Item, P4Item, P1Text, P2Text, P3Text, P4Text;
    public static int activePowerup1, activePowerup2, activePowerup3, activePowerup4;
    public GameObject LeftP1, MiddleP1, RightP1, LeftP2, MiddleP2, RightP2, LeftP3, MiddleP3, RightP3,
        LeftP4, MiddleP4, RightP4;
    public GameObject ItemSel1, ItemSel2, ItemSel3, ItemSel4;
    private string ItemSelText1, ItemSelText2, ItemSelText3, ItemSelText4;

    // Use this for initialization
    void Start()
    {
        P1Item.SetActive(false);
        P1Text.SetActive(false);
        P2Item.SetActive(false);
        P2Text.SetActive(false);
        P3Item.SetActive(false);
        P3Text.SetActive(false);
        P4Item.SetActive(false);
        P4Text.SetActive(false);
        activePowerup1 = 1;
        activePowerup2 = 1;
        activePowerup3 = 1;
        activePowerup4 = 1;
        LeftP1.SetActive(true);
        MiddleP1.SetActive(false);
        RightP1.SetActive(false);
        LeftP2.SetActive(true);
        MiddleP2.SetActive(false);
        RightP2.SetActive(false);
        LeftP3.SetActive(true);
        MiddleP3.SetActive(false);
        RightP3.SetActive(false);
        LeftP4.SetActive(true);
        MiddleP4.SetActive(false);
        RightP4.SetActive(false);
        ItemSel1.GetComponent<Text>().text = " ";
        ItemSel2.GetComponent<Text>().text = " ";
        ItemSel3.GetComponent<Text>().text = " ";
        ItemSel4.GetComponent<Text>().text = " ";
    }

    // Update is called once per frame
    void Update()
    {


        //Player 1
        if (PowerUp.P1Barric > 0 || PowerUp.P1Dyna > 0 || PowerUp.P1Trip > 0)
        {
            P1Item.SetActive(true);
            P1Text.SetActive(true);
            P1Text.GetComponent<Text>().text = "B x " + PowerUp.P1Barric + ", D x " + PowerUp.P1Dyna + ", T x " + PowerUp.P1Trip;
        }
        else
        {
            P1Item.SetActive(false);
            P1Text.SetActive(false);
        }
        //Player 2
        if (PowerUp.P2Barric > 0 || PowerUp.P2Dyna > 0 || PowerUp.P2Trip > 0)
        {
            P2Item.SetActive(true);
            P2Text.SetActive(true);
            P2Text.GetComponent<Text>().text = "B x " + PowerUp.P2Barric + ", D x " + PowerUp.P2Dyna + ", T x " + PowerUp.P2Trip;
        }
        else
        {
            P2Item.SetActive(false);
            P2Text.SetActive(false);
        }
        //Player 3
        if (PowerUp.P3Barric > 0 || PowerUp.P3Dyna > 0 || PowerUp.P3Trip > 0)
        {
            P3Item.SetActive(true);
            P3Text.SetActive(true);
            P3Text.GetComponent<Text>().text = "B x " + PowerUp.P3Barric + ", D x " + PowerUp.P3Dyna + ", T x " + PowerUp.P3Trip;
        }
        else
        {
            P3Item.SetActive(false);
            P3Text.SetActive(false);
        }
        //Player 4
        if (PowerUp.P4Barric > 0 || PowerUp.P4Dyna > 0 || PowerUp.P4Trip > 0)
        {
            P4Item.SetActive(true);
            P4Text.SetActive(true);
            P4Text.GetComponent<Text>().text = "B x " + PowerUp.P4Barric + ", D x " + PowerUp.P4Dyna + ", T x " + PowerUp.P4Trip;
        }
        else
        {
            P4Item.SetActive(false);
            P4Text.SetActive(false);
        }


        //ACTIVE POWERUPS

        if (Input.GetButtonDown("PowerCycle1"))
        {
            switch (activePowerup1)
            {
                case 1: //If Barricades currently active, switch to Dynamite
                    activePowerup1 = 2;
                    LeftP1.SetActive(false);
                    MiddleP1.SetActive(true);
                    RightP1.SetActive(false);
                    ItemSelText1 = "Dynamite";
                    StartCoroutine(PowerSelect(ItemSel1, ItemSelText1));
                    break;

                case 2: //If Dynamite currently active, switch to Trip Wire
                    activePowerup1 = 3;
                    LeftP1.SetActive(false);
                    MiddleP1.SetActive(false);
                    RightP1.SetActive(true);
                    ItemSelText1 = "Trip Wire";
                    StartCoroutine(PowerSelect(ItemSel1, ItemSelText1));
                    break;

                case 3: //If Trip Wire currently active, switch to Barricade
                    activePowerup1 = 1;
                    LeftP1.SetActive(true);
                    MiddleP1.SetActive(false);
                    RightP1.SetActive(false);
                    ItemSelText1 = "Barricade";
                    StartCoroutine(PowerSelect(ItemSel1, ItemSelText1));
                    break;
            }
        }
        if (Input.GetButtonDown("PowerCycle2"))
        {
            switch (activePowerup2)
            {
                case 1: //If Barricades currently active, switch to Dynamite
                    activePowerup2 = 2;
                    LeftP2.SetActive(false);
                    MiddleP2.SetActive(true);
                    RightP2.SetActive(false);
                    ItemSelText2 = "Dynamite";
                    StartCoroutine(PowerSelect(ItemSel2, ItemSelText2));
                    break;

                case 2: //If Dynamite currently active, switch to Trip Wire
                    activePowerup2 = 3;
                    LeftP2.SetActive(false);
                    MiddleP2.SetActive(false);
                    RightP2.SetActive(true);
                    ItemSelText2 = "Trip Wire";
                    StartCoroutine(PowerSelect(ItemSel2, ItemSelText2));
                    break;

                case 3: //If Trip Wire currently active, switch to Barricade
                    activePowerup2 = 1;
                    LeftP2.SetActive(true);
                    MiddleP2.SetActive(false);
                    RightP2.SetActive(false);
                    ItemSelText2 = "Barricade";
                    StartCoroutine(PowerSelect(ItemSel2, ItemSelText2));
                    break;
            }
        }
        if (Input.GetButtonDown("PowerCycle3"))
        {
            switch (activePowerup3)
            {
                case 1: //If Barricades currently active, switch to Dynamite
                    activePowerup3 = 2;
                    LeftP3.SetActive(false);
                    MiddleP3.SetActive(true);
                    RightP3.SetActive(false);
                    ItemSelText3 = "Dynamite";
                    StartCoroutine(PowerSelect(ItemSel3, ItemSelText3));
                    break;

                case 2: //If Dynamite currently active, switch to Trip Wire
                    activePowerup3 = 3;
                    LeftP3.SetActive(false);
                    MiddleP3.SetActive(false);
                    RightP3.SetActive(true);
                    ItemSelText3 = "Trip Wire";
                    StartCoroutine(PowerSelect(ItemSel3, ItemSelText3));
                    break;

                case 3: //If Trip Wire currently active, switch to Barricade
                    activePowerup3 = 1;
                    LeftP3.SetActive(true);
                    MiddleP3.SetActive(false);
                    RightP3.SetActive(false);
                    ItemSelText3 = "Barricade";
                    StartCoroutine(PowerSelect(ItemSel3, ItemSelText3));
                    break;
            }
        }
        if (Input.GetButtonDown("PowerCycle4"))
        {
            switch (activePowerup4)
            {
                case 1: //If Barricades currently active, switch to Dynamite
                    activePowerup4 = 2;
                    LeftP4.SetActive(false);
                    MiddleP4.SetActive(true);
                    RightP4.SetActive(false);
                    ItemSelText4 = "Dynamite";
                    StartCoroutine(PowerSelect(ItemSel4, ItemSelText4));
                    break;

                case 2: //If Dynamite currently active, switch to Trip Wire
                    activePowerup4 = 3;
                    LeftP4.SetActive(false);
                    MiddleP4.SetActive(false);
                    RightP4.SetActive(true);
                    ItemSelText4 = "Trip Wire";
                    StartCoroutine(PowerSelect(ItemSel4, ItemSelText4));
                    break;

                case 3: //If Trip Wire currently active, switch to Barricade
                    activePowerup4 = 1;
                    LeftP4.SetActive(true);
                    MiddleP4.SetActive(false);
                    RightP4.SetActive(false);
                    ItemSelText4 = "Barricade";
                    StartCoroutine(PowerSelect(ItemSel4, ItemSelText4));
                    break;
            }
        }
    }

    IEnumerator PowerSelect(GameObject IS, string IST)
    {
        IS.GetComponent<Text>().text = IST;
        yield return new WaitForSeconds(.3f);
        IS.GetComponent<Text>().text = " ";
    }
}

