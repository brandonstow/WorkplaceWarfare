using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Controls the buttons on the main menu screen, panels for controls and credits 
 * 
 * Each function is to activate it's respective panel or scene
 */

public class StartMenuUI : MonoBehaviour {

    public Canvas Controls, Credits;

    public AudioClip home;
    public AudioSource audioSource;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Controls.GetComponent<Canvas>().enabled = false;
            Credits.GetComponent<Canvas>().enabled = false;
        }
    }

    void Start()
    {
        Controls.GetComponent<Canvas>().enabled = false;
        Credits.GetComponent<Canvas>().enabled = false;

        StartCoroutine(MusicLoop());
    }
	
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ControlsMenu()
    {
        Controls.GetComponent<Canvas>().enabled = true;
    }

    public void CreditsMenu()
    {
        Credits.GetComponent<Canvas>().enabled = true;
    }

    public void BackButton()
    {
        Controls.GetComponent<Canvas>().enabled = false;
        Credits.GetComponent<Canvas>().enabled = false;
    }

    public void QuitGame()
    {
        Debug.Log("qutting Game");
        Application.Quit();
    }

    IEnumerator MusicLoop() //Loops main theme once it has finished
    {
        audioSource.PlayOneShot(home);
        yield return new WaitForSeconds(SoundManager.HomeAudio.length);
        StartCoroutine(MusicLoop());

        Debug.Log("played");

    }

}
