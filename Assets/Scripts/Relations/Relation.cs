using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relation : MonoBehaviour
{
    public UILineRenderer line;

    public Grafo grafoOrigin;
    public Grafo grafoEnd;



    public void SetGrafos(Grafo grafoA, Grafo grafoB)
    {
        grafoOrigin = grafoA;
        grafoEnd = grafoB;

        RenameRelation();
    }

    private void RenameRelation()
    {
        name = "Relation " + grafoOrigin.grafoID.text + " to " + grafoEnd.grafoID.text;
    }


    void OnEnable()
    {
        RelationsController.relations.Add(this);
    }

    void OnDisable()
    {
        RelationsController.relations.Remove(this);
    }




}
