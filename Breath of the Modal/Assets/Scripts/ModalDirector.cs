using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModalDirector : MonoBehaviour
{
    public int nowModal;
    public int numberOfDrawingModalGuideLine;

    Material lineMaterial;

	// Use this for initialization
	void Start ()
    {
		
	}
	
    void DrawLines()
    {
        if (lineMaterial == null)
            lineMaterial = LineMaterialScript.CreateLineMaterial();

        lineMaterial.SetPass(0);
        GL.PushMatrix();
        GL.Begin(GL.LINES);

        // 主線の描画
        GL.Color(new Color(1f, 1f, 0f, 0.5f));
        GL.Vertex3(0, 0, 0);
        GL.Vertex(transform.right);

        // ガイドの描画
        GL.Color(new Color(1f, 1f, 0f, 0.2f));
        for (int i = 0; i < numberOfDrawingModalGuideLine; ++i)
        {
            var q1 = ModalRotation(i);
            var q2 = ModalRotation(i + 1);
            GL.Vertex(q1 * Vector3.right);
            GL.Vertex(q2 * Vector3.right);
        }

        GL.End();
        GL.PopMatrix();
    }

	// Update is called once per frame
	void Update ()
    {
        transform.rotation = ModalRotation(nowModal);

        DrawLines();
	}

    public static Quaternion ModalRotation(int nowModal)
    {
        const float unitModal = 90f / (12f * 4f * 3f);
        const float unitAngle = 360f / 48f;
        return Quaternion.Euler(0f, unitAngle * nowModal, unitModal * nowModal);
        //return Quaternion.Euler(0f, 30f * nowModal, 7.5f * nowModal);
    }

    private void OnDrawGizmos()
    {
        transform.rotation = ModalRotation(nowModal);

        DrawLines();
    }

    public void SetModal(int nowModal)
    {
        this.nowModal = nowModal;
    }
}
