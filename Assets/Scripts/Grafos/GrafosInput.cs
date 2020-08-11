using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GrafosInput : MonoBehaviour
{
    [SerializeField] private GameObject grafoPrefab;
    [SerializeField] private GrafosController grafosPanel;

    public static bool canUserCreateGrafos = true;
    private static bool isUserClicking = false;

    private static Vector3 initialLinePoint;
    private Vector3 mousePosition;
    private Quaternion grafoRotation;
    private Transform grafoParent;
    private GameObject grafo;

    void Awake()
    {
        grafoRotation = new Quaternion();
        grafoParent = grafosPanel.transform;
    }

    void Update()
    {
        isUserClicking = Input.GetMouseButtonDown(0);
        mousePosition = Input.mousePosition;
        if ( canUserCreateGrafos && isUserClicking )
        {
            grafo = Instantiate(grafoPrefab, mousePosition, grafoRotation, grafoParent);
            //Instantiate(   what?   ,    where?    ,   rotation?  ,    parent  )
            print(initialLinePoint);
            if (initialLinePoint == Vector3.zero)
            {
                initialLinePoint = mousePosition;
            }
            else
            {
                DrawLine(mousePosition);
                initialLinePoint = mousePosition;
            }
          
        }
    }

    private void DrawLine(Vector3 finalPoint)
    {
        LineRenderer line = grafo.GetComponent<LineRenderer>();
        line.positionCount = 2;
        line.sortingOrder = 5;
        Vector3[] points = { initialLinePoint, finalPoint };
        line.SetPositions(points);
    }

}
