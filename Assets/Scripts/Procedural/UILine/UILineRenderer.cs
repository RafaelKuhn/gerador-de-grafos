
using UnityEngine;
using UnityEngine.UI;

public class UILineRenderer : Graphic
{
    private const float TAU = Mathf.PI * 2;

    public RectTransform startT, endT;

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();

        UIVertex vert = new UIVertex();
        vert.color = Color.black;

        Vector3 thicknessVector = new Vector3(0, 10); // actually half the thickness

        Vector3 xPos = new Vector3(startT.position.x, startT.position.y, 0) - thicknessVector;
        Vector3 yPos = new Vector3(endT.position.x, endT.position.y, 0) - thicknessVector;

        Vector3 xPosExtruded = new Vector3(startT.position.x, startT.position.y, 0) + thicknessVector;
        Vector3 yPosExtruded = new Vector3(endT.position.x, endT.position.y, 0) + thicknessVector;

        vert.position = xPos - transform.position; // - new Vector3(0, thickness);
        vh.AddVert(vert);

        vert.position = xPosExtruded - transform.position ; // + new Vector3(0, thickness);
        vh.AddVert(vert);

        vert.position = yPosExtruded - transform.position; // - new Vector3(0, thickness);
        vh.AddVert(vert);

        vert.position = yPos - transform.position; // + new Vector3(0, thickness);
        vh.AddVert(vert);


        vh.AddTriangle(0, 1, 2);
        vh.AddTriangle(2, 3, 0);
    }

    public void _SetPositions(Vector3 startPos, Vector3 endPos)
    {
        startT.position = startPos;
        endT.position = endPos;

        gameObject.SetActive(false);
        gameObject.SetActive(true);
    }





    void OnDrawGizmos()
    {
        // DrawStartAndEndRect();

        //Vector3 startPos = new 

        Gizmos.DrawSphere(startT.position, 3);
        Gizmos.DrawSphere(endT.position, 3);
        


        Vector3 startP = new Vector3(10, 0, 0);
        Vector3 endP = new Vector3(40, 0, 0);

        Gizmos.DrawSphere(startP, 2); // startpos

        Gizmos.DrawSphere(endP, 4); // endpos // X difference = 30

        float xdiff = endP.x - startP.x;
        float ydiff = endP.y - startP.y;

        float r2 = Mathf.Sqrt((xdiff * xdiff) + (ydiff * ydiff));









        float numberOfSpheres = 9;
        float radius = 15;
        float sphereSize = 1;

        float ang = TAU /4f * 2.5f;
        float sin = Mathf.Sin(ang);
        float cos = Mathf.Cos(ang);

        Gizmos.DrawSphere(new Vector3(radius * sin, radius * cos), 4);

        //Vector3 grafoPosition = transform.position;

        for (float angle = TAU / numberOfSpheres; angle <= TAU; angle += TAU / numberOfSpheres)
        {
            sin = Mathf.Sin(angle);
            cos = Mathf.Cos(angle);

            Vector3 eachSpherePosition = new Vector3(radius * sin, radius * cos);

            Gizmos.DrawSphere(/*grafoPosition + */eachSpherePosition, sphereSize);
        }


        //Gizmos.DrawSphere( new Vector3(Mathf.Cos(TAU / wut) * 20, Mathf.Sin(TAU / wut) * 20), 5);
    }

    void DrawStartAndEndRect()
    {
        RectTransform genRect = GetComponent<RectTransform>();

        Vector3 startPos = new Vector3(genRect.position.x - genRect.rect.width / 2,
            genRect.position.y - genRect.rect.height / 2);

        Vector3 endPos = new Vector3(genRect.position.x + genRect.rect.width / 2,
            genRect.position.y + genRect.rect.height / 2);

        Gizmos.DrawSphere(startPos, 5);
        Gizmos.DrawSphere(endPos, 5);
    }


}