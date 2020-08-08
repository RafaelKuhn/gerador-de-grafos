using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(CanvasRenderer))]
public class GrafosController : MonoBehaviour
{
    private static List<Grafo> activeGrafos = new List<Grafo>();
    private static char character = 'A';

    public static void AddToGrafos(Grafo grafo)
    {
        AssignLetter(grafo);

        activeGrafos.Add(grafo);

        Debug.Log("created grafo " + grafo.grafoID.text);
    }

    public static void RemoveFromGrafos(Grafo grafo)
    {
        activeGrafos.Remove(grafo);
    }

    private static void AssignLetter(Grafo grafo)
    {
        string s = character.ToString();
        grafo.grafoID.text = s;

        character++;
    }

    //private static void AssignIDToGrafo()













    void OnDrawGizmos()
    {
        foreach (Grafo grafo in activeGrafos)
        {
            Gizmos.DrawLine(this.transform.position, grafo.transform.position);
        }
    }
}
