using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/*
 * Activates the PauseMenu Canvas containing the Countdown, pause menu with buttons for various panels, game over canvas
 * Also contains the sliders for each player so that they can be referenced from other scripts to prevent multiple instances
 * Powerups that add or remove points are activated here in Update
 * 
 */

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public static bool gameStarted = false;
    public GameObject PauseMenuUI, CountdownUI, ControlsUI, MenuCheckUI, GameOverUI, GameOverText;
    public Slider P1Slider, P2Slider, P3Slider, P4Slider;
    private string role;
    private int MaxPoints = 1;
    bool isMute;
    public Button myInputField;

   

    void Start()
    {
        PauseMenuUI.SetActive(false);
        CountdownUI.SetActive(true);
        ControlsUI.SetActive(false);
        MenuCheckUI.SetActive(false);
        GameOverUI.SetActive(false);
        StartCoroutine(GameCountDown());
        GameIsPaused = false;
        gameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("StartButton") && gameStarted == true)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }

        if (Input.GetButtonDown("Cancel"))
        {
            ControlsUI.SetActive(false);
            MenuCheckUI.SetActive(false);
            myInputField.Select();
        }

        if ((P1Slider.value == MaxPoints || P2Slider.value == MaxPoints || P3Slider.value == MaxPoints || P4Slider.value == MaxPoints))
        {
            GameIsPaused = true;
            checkWinner();
            GameOverUI.SetActive(true);
            GameOverText.GetComponent<Text>().text = "Game Over\n\nThe " + role + " has been promoted";
            StartCoroutine(gameOver());

        }

        switch(PowerUp.pointPowerUp) //If a player collects a point power up
        {
            case 1: //Player 1
                P1Slider.value += 0.25f;
                PowerUp.pointPowerUp = 0;
                break;

            case 2: //Player 2
                P2Slider.value += 0.25f;
                PowerUp.pointPowerUp = 0;
                break;

            case 3: //Player 3
                P3Slider.value += 0.25f;
                PowerUp.pointPowerUp = 0;
                break;

            case 4: //Player 4
                P4Slider.value += 0.25f;
                PowerUp.pointPowerUp = 0;
                break;
        }

        switch (TripWires.playerNum)
        {
            case 1:
                P1Slider.value -= 0.25f;
                TripWires.playerNum = 0;
                break;

            case 2:
                P2Slider.value -= 0.25f;
                TripWires.playerNum = 0;
                break;

            case 3:
                P3Slider.value -= 0.25f;
                TripWires.playerNum = 0;
                break;

            case 4:
                P4Slider.value -= 0.25f;
                TripWires.playerNum = 0;
                break;
        }

        switch (Dynamite.dynaPlayerNum)
        {
            case 1:
                P1Slider.value -= 0.25f;
                Dynamite.dynaPlayerNum = 0;
                break;

            case 2:
                P2Slider.value -= 0.25f;
                Dynamite.dynaPlayerNum = 0;
                break;

            case 3:
                P3Slider.value -= 0.25f;
                Dynamite.dynaPlayerNum = 0;
                break;

            case 4:
                P4Slider.value -= 0.25f;
                Dynamite.dynaPlayerNum = 0;
                break;
        }
    }

    void checkWinner()
    {
        if (P1Slider.value == MaxPoints)
        {
            role = "Manager";
        }
        if (P2Slider.value == MaxPoints)
        {
            role = "Chef";
        }
        if (P3Slider.value == MaxPoints)
        {
            role = "Receptionist";
        }
        if (P4Slider.value == MaxPoints)
        {
            role = "Janitor";
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1;
    }
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0;
    }
    public void Controls()
    {
        ControlsUI.SetActive(true);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }
    public void QuitGame()
    {
        Debug.Log("qutting Game");
        Application.Quit();
    }

    public void MenuCheckPanel()
    {
        MenuCheckUI.SetActive(true);

    }

    public void NoButton()
    {
        MenuCheckUI.SetActive(false);
    }

    public void Mute()
    {
        isMute = ! isMute;
        AudioListener.volume = isMute ? 0 : 1;
    }

    IEnumerator GameCountDown() //Countsdown to start of game
    {
        CountdownUI.GetComponent<Text>().text = "5";
        SoundManager.PlaySound("Countdown");
        yield return new WaitForSeconds(1f);
        CountdownUI.GetComponent<Text>().text = "4";
        SoundManager.PlaySound("Countdown");
        yield return new WaitForSeconds(1f);
        CountdownUI.GetComponent<Text>().text = "3";
        SoundManager.PlaySound("Countdown");
        yield return new WaitForSeconds(1f);
        CountdownUI.GetComponent<Text>().text = "2";
        SoundManager.PlaySound("Countdown");
        yield return new WaitForSeconds(1f);
        CountdownUI.GetComponent<Text>().text = "1";
        SoundManager.PlaySound("Countdown");
        yield return new WaitForSeconds(1f);
        CountdownUI.GetComponent<Text>().text = "GO!";
        SoundManager.PlaySound("Start");
        gameStarted = true;
        yield return new WaitForSeconds(1.25f);
        CountdownUI.SetActive(false);


    }
    IEnumerator gameOver()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("StartMenu");
        Debug.Log("GAMEOVER");
    }

}
