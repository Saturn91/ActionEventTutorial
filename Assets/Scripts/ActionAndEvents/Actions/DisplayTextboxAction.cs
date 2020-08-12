using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTextboxAction : Action
{
    public string msg = "empty Textbox";
    public override void OnDo()
    {
        TextBox.Show(msg);
    }
}
