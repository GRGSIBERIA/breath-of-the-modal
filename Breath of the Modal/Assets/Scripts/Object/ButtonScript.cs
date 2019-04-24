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
        HitCheck();
    }

    protected override void HitCheck()
    {
        isON = Input.GetKey(code) || RayCastAll() ? true : false;

        SetMaterialColor();
    }

    protected override bool TouchHit(Vector2 pos, TouchPhase phase)
    {
        return RayCastHit(new Vector3(pos.x, pos.y, 0));
    }
}
