using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPressButtonEvent : Event
{
    public bool anyKey = false;
    public string keyValue = "Cancel";

    protected override bool EventTrue()
    {
        if (anyKey)
        {
            return Input.anyKey;
        }
        else
        {
            return Input.GetButtonDown(keyValue);
        }
    }
}
