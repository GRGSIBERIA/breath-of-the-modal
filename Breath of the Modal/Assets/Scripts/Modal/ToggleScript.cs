using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleScript : SwitchScript
{


	// Use this for initialization
	void Start ()
    {
        SwitchStart();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(code))
        {
            isON = !isON;
            material.color = isON ? pushColor : defaultColor;
        }
    }
}
