using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GrafosInput : MonoBehaviour
{
    [SerializeField] private GameObject grafoPrefab;
    [SerializeField] private GameObject linePrefab;

    [SerializeField] private Transform grafosParent;
    [SerializeField] private Transform relationsParent;

    public static bool canUserCreateGrafos { get; set; } = true;
    public static bool canUserDrawLine { get; set; } = true;

    private static bool isUserLeftClicking = false;
    private static bool isUserRightClicking = false;

    public Grafo initialGrafo { get; set; }
    
    private static Vector3 mousePosition;
    
    private static Quaternion anyRotation = new Quaternion();
    public static InputMode inputMode = InputMode.Grafo;


    void Update()
    {
        isUserLeftClicking = Input.GetMouseButtonDown(0);
        isUserRightClicking = Input.GetMouseButtonDown(1);
        mousePosition = Input.mousePosition;

        if ( isUserLeftClicking )
        {
            if (inputMode == InputMode.Grafo && canUserCreateGrafos)
                CreateGrafo();

            else if (inputMode == InputMode.ArestaSimples && CanDrawLine())
                CreateRelation();

        }

        if ( isUserRightClicking )
        { 
            DeleteIfPossible(); 
        }

    }


    private void DeleteIfPossible()
    {
        Grafo grafo = GetHoveredGrafo();      
        if (grafo != null)
        {
            List<Relation> relations = RelationsController.GetRelations(grafo);
            relations.ForEach( relation => Destroy(relation.gameObject) );
            Destroy(grafo.gameObject);
        }
    }

    private Grafo GetHoveredGrafo()
    {
        RaycastHit2D hit;

        if (hit = Physics2D.Raycast(mousePosition, Vector2.zero))
            return hit.collider.gameObject.GetComponent<Grafo>();

        return null;
    }

    private bool CanDrawLine()
    {
        bool hasInitialPoint = false;
        Grafo grafo = GetHoveredGrafo();

        if (grafo != null)
        {
            if (initialGrafo != null)
                hasInitialPoint = true;

            else
                initialGrafo = grafo;
       

            return hasInitialPoint;
        }

        return false;
    }

    private void CreateGrafo()
    {
        Instantiate(grafoPrefab, mousePosition, anyRotation, grafosParent);
    }
    private void CreateRelation()
    {
        Relation currentRelation = Instantiate(linePrefab, Vector3.zero, anyRotation, relationsParent)
            .GetComponent<Relation>();


        Grafo currentGrafo = GetHoveredGrafo();

        currentRelation.line.SetPositions(initialGrafo.transform.position, currentGrafo.transform.position);
        currentRelation.SetGrafos(initialGrafo, currentGrafo);

        Debug.Log("created relation " + initialGrafo.grafoID.text + " to " + currentGrafo.grafoID.text);

        initialGrafo = null;
    }       



}
