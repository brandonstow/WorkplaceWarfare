using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This script holds the Quick Time Event (QTE) for each terminal and creates the random sequence of buttons that appear each time it is activated
 * A variable is set to a number that corresponds with the QTE buttons. If the player then presses the correct button, the QTE will give them another button until they have successfully pressed 10 in a row
 * If the press the wrong button then the whole sequence resets and they must interact with the terminal again
 * 
 * The preventPowerups bools are to prevent a player accidently placing any items when they press triangle during a QTE
 * Strings for each of the 4 input buttons are to allow the respective player's inputs to be put in in the inspector
 */

public class Interact : MonoBehaviour
{

    public float distToPlayer;
    public float MaxDist = 3f;
    bool interactComplete = false;
    public GameObject Player, TerminalIcon;
    public Canvas QTECanvas;
    public GameObject XB, Square, Circle, Triangle, playerPrompt, TaskStrike;
    public Slider PlayerSlider;
    int QTEGen, WaitingForKey, CorrectKey, CountingDown, NumOfEvents;
    public bool StartQTE = false;
    public string SquareButton, XButton, CircleButton, TriangleButton;
    public static bool preventPowerups1 = false,  preventPowerups2 = false,  preventPowerups3 = false,  preventPowerups4 = false;

    // Use this for initialization
    void Start()
    {
        QTECanvas.GetComponent<Canvas>().enabled = false;
        XB.GetComponent<Image>().enabled = false;
        Circle.GetComponent<Image>().enabled = false;
        Triangle.GetComponent<Image>().enabled = false;
        Square.GetComponent<Image>().enabled = false;
        playerPrompt.GetComponent<Text>().text = " ";
        TaskStrike.SetActive(false);
        TerminalIcon.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        distToPlayer = Vector3.Distance(this.transform.position, Player.transform.position); //distance to Player

        InteractPressed();
        QTEEvents();

        if (NumOfEvents == 10 && QTECanvas.GetComponent<Canvas>().enabled == true) //If the max number of QTEs is reached, disable canvas
        {
            interactComplete = true;
            checkPlayerPrevent(false);
            TaskStrike.SetActive(true);
            PlayerSlider.value = PlayerSlider.value + 1;
            QTECanvas.GetComponent<Canvas>().enabled = false;
            SoundManager.PlaySound("Point");
            TerminalIcon.SetActive(false);
        }

        if (distToPlayer <= MaxDist && StartQTE == false)
        {
            playerPrompt.GetComponent<Text>().text = "Press Square";
        }
        else
        {
            playerPrompt.GetComponent<Text>().text = " ";
        }
    }

    void InteractPressed() //Checks input from player
    {
        if (Input.GetButtonDown(SquareButton) && (distToPlayer <= MaxDist) && interactComplete == false)
        {
            QTECanvas.GetComponent<Canvas>().enabled = true;
            StartCoroutine(StartDelay());
        }

    }

    void QTEEvents()
    {
        if (WaitingForKey == 0 && StartQTE == true && NumOfEvents != 10) //If needs a key, interaction is triggered and max events is not reached
        {
            checkPlayerPrevent(true);
            StartCoroutine(CountDown());
            QTEGen = Random.Range(1, 5); //Picks either 1, 2, 3, 4
            CountingDown = 1;

            if (QTEGen == 1) //Triggers X button
            {
                WaitingForKey = 1;
                XB.GetComponent<Image>().enabled = true;
            }
            if (QTEGen == 2) //Triggers Circle button
            {
                WaitingForKey = 1;
                Circle.GetComponent<Image>().enabled = true;
            }
            if (QTEGen == 3) //Triggers Square Button
            {
                WaitingForKey = 1;
                Square.GetComponent<Image>().enabled = true;
            }
            if (QTEGen == 4) //Triggers Triangle Button
            {
                WaitingForKey = 1;
                Triangle.GetComponent<Image>().enabled = true;
            }
        }

        if (QTEGen == 1)
        {
            if (Input.GetButtonDown(XButton) || Input.GetButtonDown(CircleButton) || Input.GetButtonDown(TriangleButton) || Input.GetButtonDown(SquareButton))
            {
                if (Input.GetButtonDown(XButton))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }

        if (QTEGen == 2)
        {
            if (Input.GetButtonDown(XButton) || Input.GetButtonDown(CircleButton) || Input.GetButtonDown(TriangleButton) || Input.GetButtonDown(SquareButton))
            {
                if (Input.GetButtonDown(CircleButton))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }

        if (QTEGen == 3)
        {
            if (Input.GetButtonDown(XButton) || Input.GetButtonDown(CircleButton) || Input.GetButtonDown(TriangleButton) || Input.GetButtonDown(SquareButton))
            {
                if (Input.GetButtonDown(SquareButton))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }

        if (QTEGen == 4)
        {
            if (Input.GetButtonDown(XButton) || Input.GetButtonDown(CircleButton) || Input.GetButtonDown(TriangleButton) || Input.GetButtonDown(SquareButton))
            {
                if (Input.GetButtonDown(TriangleButton))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
    }

    IEnumerator KeyPressing() //Checks if the input matches the shown QTE, resets timer, resets QTE system
    {
        QTEGen = 5;
        if (CorrectKey == 1) //correct key is pressed
        {
            SoundManager.PlaySound("QTESuccess");
            CountingDown = 2;
            Debug.Log("SUCCESS");
            yield return new WaitForSeconds(.2f);
            CorrectKey = 0;
            XB.GetComponent<Image>().enabled = false;
            Circle.GetComponent<Image>().enabled = false;
            Square.GetComponent<Image>().enabled = false;
            Triangle.GetComponent<Image>().enabled = false;
            yield return new WaitForSeconds(.5f);
            WaitingForKey = 0;
            CountingDown = 1;
            NumOfEvents++;

            // if (NumOfEvents != 10)
            //  {
            //  SoundManager.PlaySound("QTEsuccess");
            // }
        }
        if (CorrectKey == 2) //incorrect key is pressed, resets QTE
        {
            SoundManager.PlaySound("QTEFail");
            Debug.Log("FAIL");
            NumOfEvents = 0;
            QTECanvas.GetComponent<Canvas>().enabled = false;
            XB.GetComponent<Image>().enabled = false;
            Circle.GetComponent<Image>().enabled = false;
            Square.GetComponent<Image>().enabled = false;
            Triangle.GetComponent<Image>().enabled = false;
            StopCoroutine(CountDown());
            WaitingForKey = 0;
            StartQTE = false;
            interactComplete = false;
            checkPlayerPrevent(false);

        }
    }

    IEnumerator CountDown() //Counts down between each QTE, if end of coroutine is reached, timer runs out, triggers fail, resets QTE
    {
        yield return new WaitForSeconds(.7f);
        if (CountingDown == 1)
        {
            QTEGen = 5;
            CountingDown = 2;
            NumOfEvents = 0;
            QTECanvas.GetComponent<Canvas>().enabled = false;
            XB.GetComponent<Image>().enabled = false;
            Circle.GetComponent<Image>().enabled = false;
            Square.GetComponent<Image>().enabled = false;
            Triangle.GetComponent<Image>().enabled = false;
            StopCoroutine(CountDown());
            WaitingForKey = 0;
            StartQTE = false;
            interactComplete = false;
            checkPlayerPrevent(false);
        }
    }

    IEnumerator StartDelay() //Delays input detection between activating terminal and the QTEs
    {
        yield return new WaitForSeconds(.2f);
        StartQTE = true;
    }

    void checkPlayerPrevent(bool ToF) //Ensures that only the player at the terminal cannot currently place any power ups
    {
        if (Player.tag == "Player1")
        {
            preventPowerups1 = ToF;
        }
        if (Player.tag == "Player2")
        {
            preventPowerups2 = ToF;
        }
        if (Player.tag == "Player3")
        {
            preventPowerups3 = ToF;
        }
        if (Player.tag == "Player4")
        {
            preventPowerups4 = ToF;
        }
    }

}
