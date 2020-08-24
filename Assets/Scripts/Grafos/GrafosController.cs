using System.Collections.Generic;
using UnityEngine;

public class GrafosController : MonoBehaviour
{
    public static List<Grafo> grafos = new List<Grafo>();
    private static Stack<char> removedChars = new Stack<char>();

    private static char character = 'A';

    
    public static void AddToGrafos(Grafo grafo)
    {
        AssignLetter(grafo);

        grafos.Add(grafo);
        
        print("created grafo " + grafo.grafoID.text);
    }

    public static void RemoveFromGrafos(Grafo grafo) {
        grafos.Remove(grafo);
        char grafoChar = grafo.grafoID.text.ToCharArray()[0];
        removedChars.Push(grafoChar); 
    }

    private static void AssignLetter(Grafo grafo)
    {
        if(removedChars.Count == 0)
        {
            string currentChar = character.ToString();
            grafo.grafoID.text = currentChar;
            grafo.name = "grafo " + currentChar;

            character++;
        } else {
            string currentChar = removedChars.Pop().ToString();
            grafo.grafoID.text = currentChar;
        }
        
    }

    





    void OnDrawGizmosSelected()
    {
        grafos.ForEach( grafo => Gizmos.DrawLine(transform.position, grafo.transform.position) );
    }
}
