using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GrafosInput : MonoBehaviour
{
    [SerializeField] private GameObject grafoPrefab;
    [SerializeField] private GrafosController grafosPanel;

    public static bool canUserCreateGrafos = true;
    private static bool isUserClicking = false;

    private Vector3 mousePosition;
    private Quaternion grafoRotation;
    private Transform grafoParent;

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
            Instantiate(grafoPrefab, mousePosition, grafoRotation, grafoParent);
            //Instantiate(   what?   ,    where?    ,   rotation?  ,    parent  )      
        }
    }

}
