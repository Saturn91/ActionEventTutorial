using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public float mainVolume = 1;
    public Sound[] sounds;
    private static AudioManager audioManagerSingelton;
    public static AudioManager AudioManagerSingelton {  get { return audioManagerSingelton; } }
    

    // Start is called before the first frame update
    void Awake()
    {
        if (audioManagerSingelton == null)
        {
            audioManagerSingelton = this;
            DontDestroyOnLoad(gameObject);
            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.volume * mainVolume;
                s.source.pitch = s.pitch;

            }          
        }
        else
        {
            Destroy(gameObject);
        }        
    }

    private void UpdateSounds()
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = s.volume * mainVolume;
        }
    }
    
    public void SetVolume(float volume)
    {
        mainVolume = volume;
        UpdateSounds();
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            s.source.Play();
            return;
        }

        Debug.LogError("sound: " + name + " does not exist in AudioManager, please define!");

        return;

    }

    public Sound PlayInLoop(string name, float pitch)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            if(pitch > 0)
            {
                s.source.pitch = pitch;
            }

            s.source.loop = true;
            s.source.Play();
            return s;
        }

        Debug.LogError("sound: " + name + " does not exist in AudioManager, please define!");

        return null;
    }

    public Sound PlayInLoop(string name)
    {
        return PlayInLoop(name, -1);           
    }

    public void StopAllOnUnLoadRoom()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }
    }
}
