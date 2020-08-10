using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(CanvasRenderer))]
public class UICircleRenderer : Graphic
{
    private const float TAU = 6.2831f;

    [SerializeField] [Range(3, 100)] public int numberOfPoints = 8;
    [SerializeField] public float radius = 50;
    [SerializeField] public float thickness = 20;

    private float extrudedRadius;


    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();

        extrudedRadius = radius + thickness;

        UIVertex vertex = new UIVertex();
        vertex.color = color;

        if (numberOfPoints >= 3 && numberOfPoints <= 100)
        {
            //Debug.Log("circle drawn");
            float sin, cos;
            int baseVertIndex = 0;
            for (float angle = 0/*TAU / numberOfPoints*/; angle < TAU; angle += TAU / numberOfPoints)
            {
                 sin = Mathf.Sin(angle);
                 cos = Mathf.Cos(angle);

                vertex.position = new Vector3(radius * sin, radius * cos); // base vert (0)
                vh.AddVert(vertex);

                vertex.position = new Vector3(extrudedRadius * sin, extrudedRadius * cos); // extruded vert (1)
                vh.AddVert(vertex);

                float nextAngle = angle + TAU / numberOfPoints;
                sin = Mathf.Sin(nextAngle);
                cos = Mathf.Cos(nextAngle);

                //Debug.Log("angle from "+angle+" to "+nextAngle);

                vertex.position = new Vector3(extrudedRadius * sin, extrudedRadius * cos); // extruded next vert (2)
                vh.AddVert(vertex);

                vertex.position = new Vector3(radius * sin, radius * cos); // next vert (3)
                vh.AddVert(vertex);

                AddQuad(vh, baseVertIndex);
                baseVertIndex += 4;
            }
        }
    }

    private void AddQuad(VertexHelper vh, int baseVertIndex)
    {
        vh.AddTriangle(baseVertIndex, baseVertIndex+1, baseVertIndex+2); // "lower left" triangle
        vh.AddTriangle(baseVertIndex+2, baseVertIndex+3, baseVertIndex); // "upper right" trangle
    }


}
