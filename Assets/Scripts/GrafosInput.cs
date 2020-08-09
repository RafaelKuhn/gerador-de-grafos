using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GrafosInput : MonoBehaviour
{
    [SerializeField] private GameObject grafoPrefab;
    [SerializeField] private GrafosController grafosPanel;


    public bool inputtable = true;
    private bool clicking = false;

    private Vector3 grafoPosition;
    private Quaternion grafoRotation;
    private Transform grafoParent;

    void Awake()
    {
        grafoRotation = new Quaternion();
        grafoParent = grafosPanel.transform;
    }

    void Update()
    {
        clicking = Input.GetMouseButtonDown(0);
        grafoPosition = Input.mousePosition;

        if ( inputtable && clicking )
        {
            Instantiate(grafoPrefab, grafoPosition, grafoRotation, grafoParent);
            


        }
    }

}
