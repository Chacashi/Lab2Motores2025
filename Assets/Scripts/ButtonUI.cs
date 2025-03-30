using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUI : ButtonCotroller
{
    [SerializeField] private CanvasGroup canvasGroupPrincipal;

    protected override void Interactue()
    {
        if (canvasGroupPrincipal.alpha==1)
        {
            canvasGroupPrincipal.interactable = false;
            canvasGroupPrincipal.blocksRaycasts = false;
            canvasGroupPrincipal.alpha = 0;
            Time.timeScale = 1;



        }
        else
        {
            canvasGroupPrincipal.interactable = true;
            canvasGroupPrincipal.blocksRaycasts = true;
            canvasGroupPrincipal.alpha = 1;
            Time.timeScale = 0;


        }
    }
}
