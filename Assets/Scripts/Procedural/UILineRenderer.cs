﻿using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasRenderer))]
public class UILineRenderer : Graphic
{
    private const float TAU = Mathf.PI * 2;

    public RectTransform startT, endT;

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();

        UIVertex vert = new UIVertex();
        vert.color = Color.black;

        float thickness = 3f;

        float slope = (startT.position.y - endT.position.y) / (startT.position.x - endT.position.x);
        float foundAngle = Mathf.Atan(slope);

        //print("angle reference to x axis = " + (foundAngle * 360f / TAU));

        Vector3 x1Pos =
            startT.position +
            new Vector3(Mathf.Sin(TAU - foundAngle) * thickness, Mathf.Cos(TAU - foundAngle) * thickness);
        Vector3 x2Pos =
            startT.position +
            new Vector3(Mathf.Sin(TAU / 2f - foundAngle) * thickness, Mathf.Cos(TAU / 2f - foundAngle) * thickness);

        Vector3 y1Pos =
            endT.position +
            new Vector3(Mathf.Sin(TAU - foundAngle) * thickness, Mathf.Cos(TAU - foundAngle) * thickness);
        Vector3 y2Pos =
            endT.position +
            new Vector3(Mathf.Sin(TAU / 2f - foundAngle) * thickness, Mathf.Cos(TAU / 2f - foundAngle) * thickness);


        vert.position = x1Pos - transform.position;
        vh.AddVert(vert);

        vert.position = x2Pos - transform.position ;
        vh.AddVert(vert);

        vert.position = y2Pos - transform.position;
        vh.AddVert(vert);

        vert.position = y1Pos - transform.position;
        vh.AddVert(vert);


        vh.AddTriangle(0, 1, 2);
        vh.AddTriangle(2, 3, 0);
    }

    public void SetPositions(Vector3 startPos, Vector3 endPos)
    {
        if (startPos == endPos) { return; }
        // this should instead create a curve line onto itself

        startT.position = startPos;
        endT.position = endPos;

        UpdateGeometry();
    }






















    void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(startT.position, 3);
        Gizmos.DrawSphere(endT.position, 3);
    }



}