using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToggleMode : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] List<Image> buttons;
    void Start()
    {
        _ToggleInputType(0);
    }

    /// <summary>
    /// 0 : grafo
    /// 1 : simple
    /// 2 : directioned
    /// 3 : weighted
    /// </summary>
    public void _ToggleInputType(int current) // tem lógica melhor que sWItChCAsE qd ta mexendo com enum
    {
        var buttonsExceptCurrent = buttons.Where((img, index) => index != current);

        foreach (Image img in buttonsExceptCurrent) { TurnGrey(img); }
        TurnWhite( buttons[current] );

        switch (current)
        {
            case 0:
                GrafosInput.inputMode = InputMode.Grafo; break;

            case 1:
                GrafosInput.inputMode = InputMode.ArestaSimples; break;

            /*case 2:
                GrafosInput.inputMode = InputMode.ArestaPesada; break;

            case 3:
                GrafosInput.inputMode = InputMode.ArestaPesada; break; */

            default:
                throw new NotImplementedException(); break;
        }
    }

    private void TurnGrey(Image img)
    {
        img.color = Color.grey;
    }
    private void TurnWhite(Image img)
    {
        img.color = Color.white;
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
