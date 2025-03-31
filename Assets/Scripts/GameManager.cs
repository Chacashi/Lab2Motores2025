using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{


    [SerializeField] private playerController player;
    //[SerializeField] private enemysController enemy;
    [Header("Life UI")]
    //[SerializeField] private TMP_Text textLife;
    [SerializeField] private Slider sliderLife;
    
   

    [Header("Time UI")]
    [SerializeField] private TMP_Text textTime;
    [SerializeField] private float currentTime;


    [Header("State Game")]
    [SerializeField] private CanvasGroup panelLose;
    [SerializeField] private CanvasGroup panelWin;


    [Header("Buttons UI")]
    [SerializeField] private CanvasGroup ButtonsGroup;


    private void Start()
    {
        
        currentTime = 0;
       // textLife.text = "Vida: " + player.CurrentLife;
       sliderLife.value = player.CurrentLife;
        textTime.text = "Time: " + currentTime;
         
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        textTime.text = "Time: " + (int)currentTime;
        PlayerLose();
        PlayerWin();
        if (player.IsReceiveDamage)
        {
            player.SetLife(player.AddLife(player.GetDamageEnemy()));
            //textLife.text = "Vida: " + player.CurrentLife;
            sliderLife.value = player.CurrentLife;
            player.SetReceiveDamage(false);
        }
    }

    void PlayerLose()
    {
        if (player.CurrentLife <= 0 || player.Isdead == true )
        {
            Time.timeScale = 0.0f;
            panelLose.alpha = 1.0f;
            panelLose.interactable = true;
            panelLose.blocksRaycasts = true;
            ButtonsGroup.interactable = false;
            ButtonsGroup.blocksRaycasts = false;
            panelLose.GetComponentInChildren<TMP_Text>().text = "Tiempo: " + (int)currentTime;
        }
    }

    void PlayerWin()
    {
        if (player.IsTakeTacho)
        {
            Time.timeScale = 0.0f;
            panelWin.alpha = 1.0f;
            panelWin.interactable = true;
            panelWin.blocksRaycasts = true;
            ButtonsGroup.interactable = false;
            ButtonsGroup.blocksRaycasts = false;
            panelWin.GetComponentInChildren<TMP_Text>().text = "Tiempo: " + (int)currentTime;
        }

    }

   
    

    

 
}
