using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{


    [SerializeField] private playerController player;
    //[SerializeField] private enemysController enemy;
    [Header("Life")]
    [SerializeField] private TMP_Text textLife;
    [SerializeField] private CanvasGroup panelLose;
    [SerializeField] private CanvasGroup ButtonsGroup;


  
    private void Start()
    {
        textLife.text = "Vida: " + player.CurrentLife;
        
    }

    private void Update()
    {
        RestarLevel();

        if (player.IsReceiveDamage)
        {
            player.SetLife(player.AddLife(player.GetDamageEnemy()));
            textLife.text = "Vida: " + player.CurrentLife;
            player.SetReceiveDamage(false);
        }
    }

    void RestarLevel()
    {
        if (player.CurrentLife <= 0)
        {
            Time.timeScale = 0.0f;
            panelLose.alpha = 1.0f;
            panelLose.interactable = true;
            panelLose.blocksRaycasts = true;
            ButtonsGroup.interactable = false;
            ButtonsGroup.blocksRaycasts = false;
        }
    }

   
    

    

 
}
