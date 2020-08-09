using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Grafo : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI grafoID;
    [SerializeField] public Image grafoSprite;

    [SerializeField] public GameObject graphicalComponents;

    // monobehaviour
    void Awake()
    {
        // provavelmente vamo faze algo aqui
    }
    void OnEnable()
    {
        GrafosController.AddToGrafos( this );
    }

    void OnDisable()
    {
        GrafosController.RemoveFromGrafos( this );
    }







}
