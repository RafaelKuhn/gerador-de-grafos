using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasRenderer))]
public class GrafosController : MonoBehaviour
{
    public static List<GameObject> activeGrafos = new List<GameObject>();


    void OnDrawGizmos()
    {
        foreach (GameObject obj in activeGrafos)
        {
            Gizmos.DrawLine(this.transform.position, obj.transform.position);
        }
    }

}
