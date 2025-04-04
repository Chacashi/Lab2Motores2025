
using UnityEngine;
using TMPro;
using System;
public class GameManager : MonoBehaviour
{
    [Header("State Game")]
    [SerializeField] private CanvasGroup panelLose;
    [SerializeField] private CanvasGroup panelWin;

    public static event Action OnGameFinish;


    private void OnEnable()
    {
        playerController.OnPlayerDeath += PlayerLose;
        playerController.OnPlayerTakeTrush += PlayerWin;
    }

    private void OnDisable()
    {
        playerController.OnPlayerDeath -= PlayerLose;
        playerController.OnPlayerTakeTrush -= PlayerWin;
    }
    void PlayerLose()
    {

            Time.timeScale = 0.0f;
            panelLose.alpha = 1.0f;
            panelLose.interactable = true;
            panelLose.blocksRaycasts = true;
            OnGameFinish?.Invoke();  
    }

    void PlayerWin()
    {
       
            Time.timeScale = 0.0f;
            panelWin.alpha = 1.0f;
            panelWin.interactable = true;
            panelWin.blocksRaycasts = true;
            OnGameFinish?.Invoke();
    }

   
    

    

 
}
