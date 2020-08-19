using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GrafosInput : MonoBehaviour
{
    [SerializeField] private GameObject grafoPrefab;
    [SerializeField] private GrafosController grafosPanel;

    public static bool canUserCreateGrafos { get; set; } = true;

    private static bool isUserLeftClicking = false;
    private static bool isUserRightClicking = false;


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
        isUserLeftClicking = Input.GetMouseButtonDown(0);
        isUserRightClicking = Input.GetMouseButtonDown(1);
        mousePosition = Input.mousePosition;

        if ( canUserCreateGrafos && isUserLeftClicking ) { Instantiate(grafoPrefab, mousePosition, grafoRotation, grafoParent); } 
        
        if ( isUserRightClicking ) { DeleteIfPossible(); }

    }

    private void DeleteIfPossible()
    {
        RaycastHit2D hit;
        
        if (hit = Physics2D.Raycast(mousePosition, Vector2.zero))
        {
            Destroy(hit.collider.gameObject);
        }
    }




}
