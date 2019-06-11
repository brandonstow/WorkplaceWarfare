using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 *  This script is placed on each of the 4 drop zones that the players must take their objects to
 *  It constantly checks the distance of each of the 4 objects from the zone and once they are all within distance, the task is completed
 *  Once all are in zone, the task is marked as complete and a pop up appears to inform the player that, alongside a point being added
 */

public class ObjectPile : MonoBehaviour
{

    public string taskOwnerDesc; //P1, P2, P3, P4
    public bool completed = false;
    public GameObject item1, item2, item3, item4;
    public float distance1, distance2, distance3, distance4;
    public int ZoneSize = 3;
    public GameObject TaskUIObj;
    public Slider PlayerSlider;
    public float time = 5f;
    public GameObject TaskStrike, DropIcon;

    void Start()
    {
        TaskUIObj.SetActive(false); //TaskComplete text hidden
        PlayerSlider.value = 0;
        TaskStrike.SetActive(false);
        DropIcon.SetActive(true);
    }

    void Update()
    {
        distance1 = Vector3.Distance(item1.transform.position, this.transform.position);     //Distance of each object from completion area
        distance2 = Vector3.Distance(item2.transform.position, this.transform.position);
        distance3 = Vector3.Distance(item3.transform.position, this.transform.position);
        distance4 = Vector3.Distance(item4.transform.position, this.transform.position);

        Evaluate();

    }

    private void Evaluate() //Checks to see if task is completed
    {
        if (completed == false && (distance1 <= ZoneSize) && (distance2 <= ZoneSize) && (distance3 <= ZoneSize) && (distance4 <= ZoneSize)) //If all required objects are in the zone
        {
            TaskUIObj.SetActive(true);
            completed = true;
            Invoke("Hide", time); //Calls hide method
            PlayerSlider.value = PlayerSlider.value + 1;
            TaskStrike.SetActive(true);
            SoundManager.PlaySound("Point");
            DropIcon.SetActive(false);

        }

    }

    void Hide() //Removes Task Complete text after certain time
    {
        TaskUIObj.SetActive(false);

    }

}
