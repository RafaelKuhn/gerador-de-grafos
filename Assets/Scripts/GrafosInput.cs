using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GrafosInput : MonoBehaviour
{
    [SerializeField] private GameObject grafoPrefab;
    [SerializeField] private GrafosController grafosPanel;
    void Update()
    {
        if ( Input.GetMouseButtonDown(0) )
        {
            Instantiate(grafoPrefab, Input.mousePosition, new Quaternion(), grafosPanel.transform);
                
        }
    }

}
