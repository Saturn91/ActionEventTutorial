using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugAction : Action
{
    public string message;
    public override void OnDo()
    {
        Debug.Log(name + "Action: msg: " + message);
    }
}
