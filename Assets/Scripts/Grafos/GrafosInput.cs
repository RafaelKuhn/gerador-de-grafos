using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
            Instantiate(grafoPrefab, mousePosition, grafoRotation, grafoParent);
            //Instantiate(   what?   ,    where?    ,   rotation?  ,    parent  )      
        } 
        if (Input.GetMouseButtonDown(1))
        {
            print("clicou com o direito");
            CheckIfHasGrafo();
        }
    }

    private void CheckIfHasGrafo()
    {
        RaycastHit2D hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (hit = Physics2D.Raycast(mousePosition, Vector2.zero))
        {
            Destroy(hit.collider.gameObject);
        }
    }




}
