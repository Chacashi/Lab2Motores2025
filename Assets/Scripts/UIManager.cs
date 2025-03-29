using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [Header("Buttons Color")]
    [SerializeField] private Button buttonColor;
    [SerializeField] private SpriteRenderer player;

 

    private void Start()
    {
        buttonColor.onClick.AddListener(changueColor);
    }
    void changueColor()
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
