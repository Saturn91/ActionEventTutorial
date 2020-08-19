using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeEvent : Event
{
    public float lifeTime = 1f;
    public bool repeat = false;

    [SerializeField]
    private float elapsedTime = 0;
    private float startTime;
    private bool elapsed;

    public void Start()
    {
        startTime = Time.time;
    }

    protected override bool EventTrue()
    {
        if(Time.time - startTime >= lifeTime &! elapsed)
        {
            if (repeat)
            {
                startTime = Time.time;
            }
            else
            {
                elapsed = true;
            }
            return true;
        }

        if (!elapsed)
        {
            elapsedTime = Time.time - startTime;
        }

        return false;
    }

    public void Restart()
    {
        elapsed = false;
        startTime = Time.time;
    }
}
