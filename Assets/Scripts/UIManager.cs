using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [Header("Time UI")]
    [SerializeField] private TMP_Text textTime;
    [SerializeField] private float currentTime;
    [SerializeField] private TMP_Text textTimeWin;
    [SerializeField] private TMP_Text textTimeLose;

    public float CurrentTime => currentTime;

    [Header("Points UI")]
    [SerializeField] private TMP_Text textPoints;


    [Header("Life UI")]
    [SerializeField] private Slider sliderLife;


    [Header("Buttons UI")]
    [SerializeField] private CanvasGroup ButtonsGroup;


    [SerializeField] private playerController player;


    private void Start()
    {
        currentTime = 0;
        sliderLife.value = player.MaxLife;
        sliderLife.maxValue = player.MaxLife;
        textTime.text = "Time: " + currentTime;
        textPoints.text = "Puntos: " + player.CurrentPointsPlayer;
    }


    private void Update()
    {
        currentTime += Time.deltaTime;
        textTime.text = "Time: " + (int)currentTime;

    }

    private void OnEnable()
    {
        playerController.OnPlayerTakeHeart += AddPoitnsToSlider;
        playerController.OnPlayerReceiveDamage += AddPoitnsToSlider;
        playerController.OnPlayerAddPointsCoin += SetPointsToTextCoins;
        GameManager.OnGameFinish += ChangueStateButtonsGroup;
        GameManager.OnGameFinish += SetTimeTextsOnGameFinish;
    }

    private void OnDisable()
    {
        playerController.OnPlayerTakeHeart -= AddPoitnsToSlider;
        playerController.OnPlayerReceiveDamage -= AddPoitnsToSlider;
        playerController.OnPlayerAddPointsCoin -= SetPointsToTextCoins;
        GameManager.OnGameFinish -= ChangueStateButtonsGroup;
        GameManager.OnGameFinish -= SetTimeTextsOnGameFinish;
    }




    void AddPoitnsToSlider(int points)
    {
        sliderLife.value += points;
    }
    void SetPointsToTextCoins()
    {
        textPoints.text = "Puntos: " + player.CurrentPointsPlayer;
    }

    void ChangueStateButtonsGroup()
    {
        ButtonsGroup.interactable = false;
        ButtonsGroup.blocksRaycasts = false;
    }

    void SetTimeTextsOnGameFinish()
    {
        textTimeWin.text = "Time: " + (int)currentTime;
        textTimeLose.text = "Time: " + (int)currentTime;
    }
}
