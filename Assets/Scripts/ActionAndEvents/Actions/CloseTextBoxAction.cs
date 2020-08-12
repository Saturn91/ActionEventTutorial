using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTextBoxAction : Action
{
    public override void OnDo()
    {
        TextBox.Hide();
    }
}
