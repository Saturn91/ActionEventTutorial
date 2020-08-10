using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSceneAction : Action
{
    public string scene = "samplescene";

    public override void OnDo()
    {
        try
        {
            SceneManager.LoadScene(scene);
        }
        catch
        {
            Debug.LogError("not able to locate: " + scene);
        }
    }
}
