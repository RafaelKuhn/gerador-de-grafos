using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exporter : MonoBehaviour
{
    List<Grafo> allGrafos;
    Dictionary<Grafo, List<Relation>> allRelations;
    public void _Export()
    {
        allGrafos = GrafosController.grafos;
        allRelations = PopulateRelations(allGrafos);

        print("all relations:");
        foreach ( List<Relation> relations in allRelations.Values )
            foreach ( Relation relation in relations )
                print ( "\n"+relation.grafoOrigin.grafoID+" to "+relation.grafoEnd.grafoID );

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
