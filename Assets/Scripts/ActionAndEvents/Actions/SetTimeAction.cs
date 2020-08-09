using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTimeAction : Action
{
    public float timeScale = 1;

    public override void OnDo()
    {
        Time.timeScale = timeScale;
    }
}
