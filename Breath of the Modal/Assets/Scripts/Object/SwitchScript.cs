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

    private new Collider collider;

    protected void SwitchStart ()
    {
        material = GetComponent<MeshRenderer>().materials[0];
        material.color = defaultColor;
        collider = GetComponent<Collider>();
    }
	
    protected virtual void HitCheck() { }

    public bool IsON()
    {
        return isON;
    }

    protected bool RayCastHit(Vector3 hitpos)
    {
        Ray ray = Camera.main.ScreenPointToRay(hitpos);
        RaycastHit hit;

        Physics.Raycast(ray, out hit);

        return hit.collider == collider;
    }

    protected bool RayCastAll()
    {
        int count = Input.touchCount;
        for (int i = 0; i < count; ++i)
        {
            var touch = Input.GetTouch(i);
            var pos = touch.position;

            if (TouchHit(pos, touch.phase))
                return true;
        }
        return false;
    }

    protected virtual bool TouchHit(Vector2 pos, TouchPhase phase)
    {
        throw new System.NotImplementedException();
    }

    protected void SetMaterialColor()
    {
        material.color = isON ? pushColor : defaultColor;
    }
}
