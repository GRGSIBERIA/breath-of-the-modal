using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

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
        }
        else
        {
            material.color = defaultColor;
        }
	}
}
