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

    [SerializeField] public GameObject linePrefab;

    private const float TAU = Mathf.PI * 2;

   

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

        GrafosInput.canUserCreateGrafos = true;
    }






















    void OnDrawGizmosSelected()
    {
        DrawCircleOfSpheres(30);
    }

    void DrawCircleOfSpheres(int numberOfSpheres)
    {
        float radius = 100;
        float sphereSize = 3;
        Vector3 grafoPosition = transform.position;

        for (float angle = TAU / numberOfSpheres; angle <= TAU; angle += TAU / numberOfSpheres)
        {
            float sin = Mathf.Sin(angle);
            float cos = Mathf.Cos(angle);

            Vector3 eachSpherePosition = new Vector3(radius * sin, radius * cos);

            Gizmos.DrawSphere(grafoPosition + eachSpherePosition, sphereSize);
        }
    }
}
