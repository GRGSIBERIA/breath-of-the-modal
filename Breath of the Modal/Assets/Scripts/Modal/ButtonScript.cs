using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : SwitchScript {

    public Color defaultColor;

    public Color pushColor;

    public KeyCode code;
    
    Material material;

	// Use this for initialization
	void Start ()
    {
        material = GetComponent<MeshRenderer>().materials[0];
        material.color = defaultColor;
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
