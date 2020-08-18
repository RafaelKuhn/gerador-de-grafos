using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(CanvasRenderer))]
public class GrafosController : MonoBehaviour
{
    private static List<Grafo> grafos = new List<Grafo>();

    private static char character = 'A';


    public static void AddToGrafos(Grafo grafo)
    {
        AssignLetter(grafo);

        DrawLine(grafo);

        grafos.Add(grafo);
        
        Debug.Log("created grafo " + grafo.grafoID.text);
    }

    public static void RemoveFromGrafos(Grafo grafo)
    {
        int grafoIndex = grafos.IndexOf(grafo);
        if (grafoIndex != 0)
        {
            Grafo previousGrafo = grafos[grafoIndex - 1];
            Destroy(previousGrafo.GetComponentInChildren<UILineRenderer>().gameObject);
        }
        grafos.Remove(grafo);      
    }

    private static void AssignLetter(Grafo grafo)
    {
        string currentChar = character.ToString();
        grafo.grafoID.text = currentChar;
        grafo.name = "grafo " + currentChar;

        character++;
    }

    private static void DrawLine(Grafo grafo)
    {
        if (grafos.Count >= 1)
            grafos[grafos.Count - 1].ConnectToAnotherGrafo(grafo);
   
        // grafos.count - 1 is the last grafo before this grafo
    }
    





    void OnDrawGizmos()
    {
        foreach (Grafo grafo in grafos)
        {
            Gizmos.DrawLine(this.transform.position, grafo.transform.position);
        }
    }
}
