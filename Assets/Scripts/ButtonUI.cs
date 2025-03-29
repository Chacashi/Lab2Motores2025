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
            
         
        }
        else
        {
            canvasGroupPrincipal.interactable = true;
            canvasGroupPrincipal.blocksRaycasts = true;
            
          
        }
    }
}
