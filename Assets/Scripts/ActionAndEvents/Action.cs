using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour
{
    public bool active = true;
    public bool debug;
    public string id = "undefined";
    public void Do()
    {
        if (active)
        {
            if (debug)
            {
                Debug.Log("Action: " + id + " has fired!");
            }
            OnDo();
        }
    }
    public abstract void OnDo();
}
