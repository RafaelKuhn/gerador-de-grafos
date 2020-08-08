using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Grafo : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI grafoID;

    // mono
    void OnEnable()
    {
        GrafosController.AddToGrafos( this );
    }
    void OnDisable()
    {
        GrafosController.RemoveFromGrafos( this );
    }



}
