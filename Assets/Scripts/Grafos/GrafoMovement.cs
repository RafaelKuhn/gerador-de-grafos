using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class GrafoMovement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler
{
    [SerializeField] public Grafo grafo;
    [SerializeField] public Image dragImage;

    private Transform grafoLocation;
    private RectTransform grafoRect;


    private Vector3 relationStartPos;
    private Vector3 relationEndPos;

    private UILineRenderer line;

    private static Color opaque = new Color(1, 1, 1, 1);
    private static Color transparent = new Color(1, 1, 1, 0);

    private static Vector3 sizeOffset = new Vector3(0.3f, 0.3f, 0.3f);


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

    private Vector3 lastPos;
    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (GrafosInput.inputMode != InputMode.Grafo) { return; }

        grafoRect.anchoredPosition += eventData.delta;

        RelationsController.GetRelations(grafo)
            .ForEach((rel) => rel.line.SetPositions(rel.grafoOrigin.transform.position, rel.grafoEnd.transform.position));
    }

    
}
