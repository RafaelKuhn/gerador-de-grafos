using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LineToggleButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text text;
    [SerializeField]
    private bool isLineModeOn;  

    public void UpdateMode()
    {
        if (isLineModeOn)
        {
            text.text = "Line Mode: Off";
            isLineModeOn = false;
            GetComponent<Image>().color = Color.gray;
            GrafosInput.inputMode = InputMode.grafo;
        }
        else
        {
            text.text = "Line Mode: On";
            isLineModeOn = true;
            GetComponent<Image>().color = Color.white;
            GrafosInput.inputMode = InputMode.line;
        }
            
    }


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
