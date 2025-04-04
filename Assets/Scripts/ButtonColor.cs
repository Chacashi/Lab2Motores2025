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
        if (player.gameObject.GetComponent<playerController>().CanChangueColor == true)
        {
            switch (buttonColor.tag)
            {
                case "red":
                    player.color = Color.red;
                    player.gameObject.layer = 7;
                    break;
                case "blue":
                    player.color = Color.blue;
                    player.gameObject.layer = 9;
                    break;
                case "green":
                    player.color = Color.green;
                    player.gameObject.layer = 8;
                    break;
                default:
                    break;
            }
        }
          
    }



  

}
