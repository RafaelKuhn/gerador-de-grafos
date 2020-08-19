using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasRenderer))]
public class GrafosController : MonoBehaviour
{
    public static List<Grafo> grafos = new List<Grafo>();

    private static char character = 'A';

    
    public static void AddToGrafos(Grafo grafo)
    {
        AssignLetter(grafo);

        grafos.Add(grafo);
        
        print("created grafo " + grafo.grafoID.text);
    }

    public static void RemoveFromGrafos(Grafo grafo) { grafos.Remove(grafo); }

    private static void AssignLetter(Grafo grafo)
    {
        string currentChar = character.ToString();
        grafo.grafoID.text = currentChar;
        grafo.name = "grafo " + currentChar;

        character++;
    }

    





    void OnDrawGizmosSelected()
    {
        grafos.ForEach( grafo => Gizmos.DrawLine(transform.position, grafo.transform.position) );
    }
}
