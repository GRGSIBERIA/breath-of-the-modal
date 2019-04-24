using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleManagerScript : MonoBehaviour {

    SwitchScript[] switches;

    public int Register { get; private set; }

	// Use this for initialization
	void Start ()
    {
        switches = new SwitchScript[transform.childCount];
        for (int i = 0; i < switches.Length; ++i)
        {
            var comp = transform.GetChild(i).GetComponent<SwitchScript>();
            switches[comp.buttonNumber] = comp;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        Register = 0;
		for (int i = 0; i < switches.Length; ++i)
        {
            if (switches[i].IsON())
                Register |= 1 << i;
        }
	}
}
