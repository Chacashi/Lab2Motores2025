using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOpc : ButtonCotroller
{
    [SerializeField] private CanvasGroup canvasGroupObjective;
    [SerializeField] private CanvasGroup[] arrayCanvasGroup;


    protected override void Interactue()
    {
        if (canvasGroupObjective.alpha == 0)
        {
            for (int i = 0; i < arrayCanvasGroup.Length; i++)
            {
                arrayCanvasGroup[i].alpha = 0;
                arrayCanvasGroup[i].interactable = false;
                arrayCanvasGroup[i].blocksRaycasts = false;
            }
        }
    }
}
