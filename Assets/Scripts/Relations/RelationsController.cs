using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelationsController : MonoBehaviour
{
    public static List<Relation> relations = new List<Relation>();

    public static List<Relation> GetRelations(Grafo grafoBeingSearched)
    {
        List<Relation> foundRelations = new List<Relation>();

        foreach (Relation currentRelation in relations)
            if (currentRelation.grafoOrigin.Equals(grafoBeingSearched) || currentRelation.grafoEnd.Equals(grafoBeingSearched))
                foundRelations.Add(currentRelation);

        return foundRelations;
    }
}
