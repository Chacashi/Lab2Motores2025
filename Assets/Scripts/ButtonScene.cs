using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScene : ButtonCotroller
{
    [Header("Atributtes")]
    [SerializeField] private string scene;
    protected override void Start()
    {
        Time.timeScale = 1.0f;
        base.Start();
    }
    protected override void Interactue()
    {
       
        SceneManager.LoadScene(scene);
        
    }
}
