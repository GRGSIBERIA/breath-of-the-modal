using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : SwitchScript
{
	// Use this for initialization
	void Start ()
    {
        SwitchStart();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(code))
        {
            material.color = pushColor;
            isON = true;
        }
        else
        {
            material.color = defaultColor;
            isON = false;
        }
    }
}
