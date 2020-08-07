using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger2DEvent : Event
{
    public string targetTag = "Player";
    private bool eventTrue = false;
    protected override bool EventTrue()
    {
        bool temp = eventTrue;
        eventTrue = false;
        return temp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        eventTrue = collision.tag == targetTag;
    }
}
