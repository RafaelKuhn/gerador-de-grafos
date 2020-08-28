using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GrafosInput : MonoBehaviour
{
    [SerializeField] private GameObject grafoPrefab;
    [SerializeField] private GameObject relationPrefab;

    [SerializeField] private Transform grafosParent;
    [SerializeField] private Transform relationsParent;

    public static bool canUserCreateGrafos { get; set; } = true;
    public static bool canUserDrawLine { get; set; } = true;

    // mouse data
    private static bool isUserLeftClicking = false;
    private static bool isUserRightClicking = false;
    private static Vector3 mousePosition;

    public Grafo initialGrafo { get; set; }
    
    
    private static Quaternion anyRotation = new Quaternion();
    public static InputMode inputMode = InputMode.Grafo;


    void Update()
    {
        GetMouseData();

        if ( isUserLeftClicking )
        {
            if ( CanCreateGrafos() )
                CreateGrafo();

            else if ( CanCreateRelation() )
                CreateRelation();
        }

        if ( isUserRightClicking )
        { 
            DeleteGrafoOrRelation(); 
        }

    }

    private void GetMouseData()
    {
        isUserLeftClicking = Input.GetMouseButtonDown(0);
        isUserRightClicking = Input.GetMouseButtonDown(1);
        mousePosition = Input.mousePosition;
    }
    private void DeleteGrafoOrRelation()
    {
        if (inputMode == InputMode.Grafo)
            DeleteGrafoAndItsRelations( GetHoveredGrafo() );

        else
            DeleteRelations(RelationsController.GetRelationsBothWays( GetHoveredGrafo() ) );


    }

    private void DeleteGrafoAndItsRelations(Grafo grafo)
    {
        if (grafo != null)
        {
            DeleteRelations( RelationsController.GetRelationsBothWays(grafo) );
            
            Destroy(grafo.gameObject);
        }
    }

    private void DeleteRelations(List<Relation> relations)
    {
        relations.ForEach( relation => Destroy(relation.gameObject) );
    }

    private Grafo GetHoveredGrafo()
    {
        RaycastHit2D hit;

        if (hit = Physics2D.Raycast(mousePosition, Vector2.zero))
            return hit.collider.gameObject.GetComponent<Grafo>();

        return null;
    }

    private bool CanCreateGrafos()
    {
        if (inputMode != InputMode.Grafo) { return false; }

        if (canUserCreateGrafos)
            return true;

        else
            return false;
    }

    private bool CanCreateRelation()
    {
        if (inputMode != InputMode.ArestaSimples) { return false; }

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
        Relation currentRelation = Instantiate(relationPrefab, Vector3.zero, anyRotation, relationsParent)
            .GetComponent<Relation>();

        Grafo currentGrafo = GetHoveredGrafo();

        currentRelation.line.SetPositions(initialGrafo.transform.position, currentGrafo.transform.position);
        currentRelation.SetGrafos(initialGrafo, currentGrafo);

        Debug.Log("created relation " + initialGrafo.grafoID.text + " to " + currentGrafo.grafoID.text);

        initialGrafo = null;
    }       



}
