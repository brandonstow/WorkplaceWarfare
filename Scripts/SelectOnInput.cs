﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class SelectOnInput : MonoBehaviour {

    public EventSystem eventSystem;
    public GameObject selectedObj;
    private bool buttonSelected;

	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {

		if (Input.GetAxisRaw("Horizontal") != 0 && buttonSelected == false) //If Input detected and no button is selected
        {
            eventSystem.SetSelectedGameObject(selectedObj);
            buttonSelected = true;
        }
	}

    private void OnDisable()
    {
        buttonSelected = false;
    }
}
