using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Exporter : MonoBehaviour
{
    [SerializeField] private TMP_InputField outputField;

    List<Grafo> allGrafos;
    Dictionary<Grafo, List<Relation>> allRelations;
    public void _Export()
    {
        allGrafos = GrafosController.grafos;
        allRelations = PopulateRelations(allGrafos);

        string s = "";

        foreach ( List<Relation> relations in allRelations.Values )
            foreach ( Relation relation in relations )
                s += relation.grafoOrigin.grafoID.text+" to "+relation.grafoEnd.grafoID.text+", ";

        outputField.text = s;

        CreateTable();

    }

    
    private void CreateTable()
    {

    }


    void ParseRelations(List<Relation> relations)
    {
        //relations.ForEach( ProcessRelation )


    }





    private Dictionary<Grafo, List<Relation>> PopulateRelations(List<Grafo> allGrafos)
    {
        allRelations = new Dictionary<Grafo, List<Relation>>();

        foreach (Grafo grafo in allGrafos)
            allRelations.Add(grafo, RelationsController.GetRelations(grafo));

        return allRelations;
    }
}
