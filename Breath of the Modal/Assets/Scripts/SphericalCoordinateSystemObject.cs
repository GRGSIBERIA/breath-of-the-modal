using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphericalCoordinateSystemObject : MonoBehaviour
{
    Material lineMaterial;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    private void OnRenderObject()
    {
        DrawLines();
    }

    private void DrawLines()
    {
        if (lineMaterial == null)
            lineMaterial = LineMaterialScript.CreateLineMaterial();

        lineMaterial.SetPass(0);
        GL.PushMatrix();
        GL.Begin(GL.LINES);

        var cx = new Color(1f, 0f, 0f, 0.2f);
        var cy = new Color(0f, 1f, 0f, 0.2f);
        var cz = new Color(0f, 0f, 1f, 0.2f);

        for (int i = 0; i < 128; ++i)
        {
            float a = (i / 128.0f) * Mathf.PI * 2;
            float b = ((i + 1) / 128.0f) * Mathf.PI * 2;

            GL.Color(cz);
            GL.Vertex3(Mathf.Cos(a), Mathf.Sin(a), 0);
            GL.Vertex3(Mathf.Cos(b), Mathf.Sin(b), 0);

            GL.Color(cx);
            GL.Vertex3(0, Mathf.Cos(a), Mathf.Sin(a));
            GL.Vertex3(0, Mathf.Cos(b), Mathf.Sin(b));

            GL.Color(cy);
            GL.Vertex3(Mathf.Cos(a), 0, Mathf.Sin(a));
            GL.Vertex3(Mathf.Cos(b), 0, Mathf.Sin(b));
        }

        GL.Color(cx);
        GL.Vertex3(-1, 0, 0);
        GL.Vertex3(1, 0, 0);

        GL.Color(cy);
        GL.Vertex3(0, -1, 0);
        GL.Vertex3(0, 1, 0);

        GL.Color(cz);
        GL.Vertex3(0, 0, -1);
        GL.Vertex3(0, 0, 1);

        GL.End();
        GL.PopMatrix();
    }

    private void OnDrawGizmos()
    {
        DrawLines();
    }
}
