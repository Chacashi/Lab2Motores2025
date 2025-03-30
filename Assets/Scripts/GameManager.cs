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
    [Header("Life UI")]
    [SerializeField] private TMP_Text textLife;
    [SerializeField] private CanvasGroup panelLose;
    [SerializeField] private CanvasGroup ButtonsGroup;

    [Header("Time UI")]
    [SerializeField] private TMP_Text textTime;
    [SerializeField] private float currentTime;


  
    private void Start()
    {
        
        currentTime = 0;
        textLife.text = "Vida: " + player.CurrentLife;
        textTime.text = "Time: " + currentTime;
         
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        textTime.text = "Time: "+ (int)currentTime;
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
