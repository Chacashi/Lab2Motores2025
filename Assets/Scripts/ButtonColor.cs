using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class ButtonColor : ButtonCotroller
{
    [Header("Atributtes")]
    [SerializeField] private Button buttonColor;
    [SerializeField] private SpriteRenderer player;
    

    protected override void Interactue()
    {
        
        switch (buttonColor.tag)
            {
                case "red":
                    player.color = Color.red;
                    break;
                case "blue":
                    player.color = Color.blue;
                    break;
                case "yellow":
                    player.color = Color.yellow;
                    break;
                default:
                    break;
            }    
    }



  

}
