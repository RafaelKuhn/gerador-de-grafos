using UnityEngine;
using UnityEngine.EventSystems;

public class DisableInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        GrafosInput.canUserCreateGrafos = false;
        GrafosInput.canUserDrawLine = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GrafosInput.canUserCreateGrafos = true;
        GrafosInput.canUserDrawLine = true;
    }
}
