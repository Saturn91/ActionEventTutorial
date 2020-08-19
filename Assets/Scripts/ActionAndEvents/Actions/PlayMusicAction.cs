using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicAction : Action
{
    public string musicTitleId;
    public override void OnDo()
    {
        MusicManager.MusicManagerSingelton.Play(musicTitleId);
    }
}
