using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grafo : MonoBehaviour
{
    void OnEnable()
    {
        GrafosController.activeGrafos.Add( this.gameObject );
    }


    void OnDisable()
    {
        GrafosController.activeGrafos.Remove( this.gameObject );
    }
}
