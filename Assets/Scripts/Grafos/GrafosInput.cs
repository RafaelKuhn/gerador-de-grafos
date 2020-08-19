using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GrafosInput : MonoBehaviour
{
    [SerializeField] private GameObject grafoPrefab;
    [SerializeField] private GrafosController grafosPanel;
    [SerializeField] private GameObject linePrefab;

    public static bool canUserCreateGrafos { get; set; } = true;
    public static bool canUserDrawLine { get; set; } = true;

    private static bool isUserLeftClicking = false;
    private static bool isUserRightClicking = false;

    private Vector3 initialLinePoint;
    private Vector3 mousePosition;
    private Quaternion grafoRotation;
    private Transform grafoParent;
    public static InputMode inputMode = InputMode.grafo;


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

        if ( canUserCreateGrafos && isUserLeftClicking && inputMode == InputMode.grafo) {
                Instantiate(grafoPrefab, mousePosition, grafoRotation, grafoParent);           
        }
        else if (isUserLeftClicking && inputMode == InputMode.line)
        {
            if (CanDrawLine()) { DrawLine(); }         
        }

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

    private bool CanDrawLine()
    {
        bool hasInitialPoint = false;
        if (canUserDrawLine)
        {
            if (initialLinePoint != Vector3.zero)
                hasInitialPoint = true;
            else
            {
                hasInitialPoint = false;
                initialLinePoint = mousePosition;
            }
        }
        
        return hasInitialPoint && canUserDrawLine;
    }

    private void DrawLine()
    {
        GameObject line = Instantiate(linePrefab, grafoParent);
        line.GetComponent<UILineRenderer>()._SetPositions(initialLinePoint, mousePosition);
        initialLinePoint = Vector3.zero;
    }



}
