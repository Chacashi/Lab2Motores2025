using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonExit : ButtonCotroller
{
    protected override void Interactue()
    {
        print("Saliste");
        Application.Quit();
    }
}
