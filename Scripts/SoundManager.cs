using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * All sounds are contained in this file and can be called from any other script
 * Each audioclip is in a switch statement with a string case that takes the name of the clip
 * The PlaySound function can be called from any script with the parameter of the name of the clip that is needed
 * 
 * The game audio is also started and once it has finished, it restarts
 */

public class SoundManager : MonoBehaviour {

    public static AudioClip CountdownAudio, StartAudio, TaskMapAudio, PointAudio, MenuAudio,
        PickupAudio, BarricadeAudio, GrabAudio, QTESuccessAudio, QTEFailAudio, PowerUpAudio, HomeAudio, GameAudio, DynamiteAudio, TripwireAudio;
    static AudioSource audioSource;
	// Use this for initialization
	void Start () {

        CountdownAudio = Resources.Load<AudioClip>("Countdown");
        StartAudio = Resources.Load<AudioClip>("Start");
        TaskMapAudio = Resources.Load<AudioClip>("TaskMap");
        PointAudio = Resources.Load<AudioClip>("Point");
        MenuAudio = Resources.Load<AudioClip>("Menu");
        PickupAudio = Resources.Load<AudioClip>("Pickup");
        BarricadeAudio = Resources.Load<AudioClip>("Barricade");
        GrabAudio = Resources.Load<AudioClip>("Grab");
        QTESuccessAudio = Resources.Load<AudioClip>("QTESuccess");
        QTEFailAudio = Resources.Load<AudioClip>("QTEFail");
        PowerUpAudio = Resources.Load<AudioClip>("PowerUp");
        HomeAudio = Resources.Load<AudioClip>("Home");
        GameAudio = Resources.Load<AudioClip>("Game");
        DynamiteAudio = Resources.Load<AudioClip>("Dynamite");
        TripwireAudio = Resources.Load<AudioClip>("Tripwire");

        audioSource = GetComponent<AudioSource>();

        StartCoroutine(MusicLoop());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "Countdown":
                audioSource.PlayOneShot(CountdownAudio);
                break;
            case "Start":
                audioSource.PlayOneShot(StartAudio);
                break;
            case "TaskMap":
                audioSource.PlayOneShot(TaskMapAudio);
                break;
            case "Point":
                audioSource.PlayOneShot(PointAudio);
                break;
            case "Menu":
                audioSource.PlayOneShot(MenuAudio);
                break;
            case "Pickup":
                audioSource.PlayOneShot(PickupAudio);
                break;
            case "Barricade":
                audioSource.PlayOneShot(BarricadeAudio);
                break;
            case "Grab":
                audioSource.PlayOneShot(GrabAudio);
                break;
            case "QTESuccess":
                audioSource.PlayOneShot(QTESuccessAudio);
                break;
            case "QTEFail":
                audioSource.PlayOneShot(QTEFailAudio);
                break;
            case "PowerUp":
                audioSource.PlayOneShot(PowerUpAudio);
                break;
            case "Home":
                audioSource.PlayOneShot(HomeAudio);
                break;
            case "Game":
                audioSource.PlayOneShot(GameAudio);
                break;
            case "Dynamite":
                audioSource.PlayOneShot(DynamiteAudio);
                break;
            case "Tripwire":
                audioSource.PlayOneShot(TripwireAudio);
                break;
        }
    }

    IEnumerator MusicLoop() //Loops main theme once it has finished
    {
        PlaySound("Game");
        yield return new WaitForSeconds(GameAudio.length);
        StartCoroutine(MusicLoop());

    }

}
