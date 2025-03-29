using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract public class ButtonCotroller : MonoBehaviour
{
    protected Button myButton;

    protected virtual void Awake()
    {
        myButton = GetComponent<Button>();
    }

    protected virtual void Start()
    {
        myButton.onClick.AddListener(Interactue);
    }
    protected abstract void Interactue();
    



}
