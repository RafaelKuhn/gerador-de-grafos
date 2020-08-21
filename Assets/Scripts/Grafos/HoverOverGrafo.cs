using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEditor.EventSystems;


public class HoverOverGrafo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler,
                                IDragHandler
{
    [SerializeField] public Grafo grafo;
    [SerializeField] public Image dragImage;

    private Transform grafoLocation;
    private RectTransform grafoRect;

    private Color opaque = new Color(1, 1, 1, 1);
    private Color transparent = new Color(1, 1, 1, 0);

    private Vector3 sizeOffset = new Vector3(0.3f, 0.3f, 0.3f);

    private Vector3 endLinePosition;
    private UILineRenderer line;

    //private bool draggable;

    void Awake()
    {
        grafoLocation = grafo.graphicalComponents.transform;
        grafoRect = grafo.GetComponent<RectTransform>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        GrafosInput.canUserCreateGrafos = false;

        grafoLocation.localScale += sizeOffset;
        dragImage.color = opaque; 

        //draggable = true;
        // change this to a smooth transition with Lerp function(s?) inside coroutine
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GrafosInput.canUserCreateGrafos = true;

        grafoLocation.localScale -= sizeOffset;
        dragImage.color = transparent;
        
        //draggable = false;
    }

    
    public void OnBeginDrag(PointerEventData eventData)
    {
        print("ae");
        if(line = grafo.GetComponentInChildren<UILineRenderer>())
            endLinePosition = line.endT.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        grafoRect.anchoredPosition += eventData.delta;
        if (line != null)
        {
            line._SetPositions(line.startT.position, endLinePosition);
        }
    }

    
}
