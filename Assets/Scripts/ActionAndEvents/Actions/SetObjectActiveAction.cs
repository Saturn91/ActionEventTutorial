using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjectActiveAction : Action
{
    public GameObject[] gameObjects;
    public bool setObjectActive = true;
    public override void OnDo()
    {
        foreach(GameObject go in gameObjects)
        {
            go.SetActive(setObjectActive);
        }
    }
}
