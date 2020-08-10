using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGameAction : Action
{
    public override void OnDo()
    {
        Application.Quit();
    }
}
