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
        HitCheck();
    }

    protected override void HitCheck()
    {
        if (Input.GetKeyDown(code) || RayCastAll())
            isON = !isON;

        SetMaterialColor();
    }

    protected override bool TouchHit(Vector2 pos, TouchPhase phase)
    {
        if (RayCastHit(new Vector3(pos.x, pos.y, 0)))
        {
            return phase == TouchPhase.Began ? true : false;
        }
        return false;
    }
}
