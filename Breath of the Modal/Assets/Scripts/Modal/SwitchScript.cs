using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    public int buttonNumber;

    public Color defaultColor;

    public Color pushColor;

    public KeyCode code;

    protected bool isON;

    protected Material material;

    protected void SwitchStart ()
    {
        material = GetComponent<MeshRenderer>().materials[0];
        material.color = defaultColor;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    public bool IsON()
    {
        return isON;
    }
}
