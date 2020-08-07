using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Event: MonoBehaviour
{
    public Action[] actions;
    public string eventId;
    public bool debug;
    public bool fireOnlyOnce = false;
    public bool enabled = true;

    private void Update()
    {
        if (EventTrue())
        {
            OnDo();
        }
    }    

    protected void OnDo()
    {
        if (enabled)
        {
            if (fireOnlyOnce)
            {
                enabled = false;
            }
            if (debug)
            {
                Debug.Log("Event:" + eventId + ", " + name + " has fired!");
            }
            foreach (Action a in actions)
            {
                try
                {
                    a.Do();
                }
                catch (System.Exception e)
                {
                    Debug.LogError("unexpectet error while do... [" + name + "." + a.GetType().Name + "]: " + e);
                }
            }
        }
    }

    protected abstract bool EventTrue();
}
