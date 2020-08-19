using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MusicManager : MonoBehaviour
{
    public float mainVolume = 1;
    public string startMusic = "";
    private Sound currentMusic;

    public Sound[] sounds;

    private static MusicManager musicManagerSingelton;
    public static MusicManager MusicManagerSingelton {  get { return musicManagerSingelton; } }

    private string actualMusicTitle = "null";

    // Start is called before the first frame update
    void Awake()
    {
        if (musicManagerSingelton == null)
        {
            DontDestroyOnLoad(gameObject);
            musicManagerSingelton = this;
            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.volume * mainVolume;
                s.source.pitch = s.pitch;
                s.source.loop = true;
            }

            if (startMusic != "")
            {
                musicManagerSingelton.Play(startMusic);
            }
        }
        else
        {
            if (startMusic != "")
            {
                musicManagerSingelton.Play(startMusic);
            }
            Debug.Log("Destroy!");
            Destroy(gameObject);
        }  
        
        
    }

    public void Play(string name)
    {
        Debug.Log("Play: " + name);
        Play(name, 0);                 
    }

    public void Play(string name, float position)
    {
        if (!actualMusicTitle.Equals(name))
        {
            if (currentMusic != null)
            {
                currentMusic.source.Stop();
            }
            currentMusic = Array.Find(sounds, sound => sound.name == name);
            if (currentMusic != null)
            {
                if (currentMusic.source != null)
                {
                    actualMusicTitle = name;
                    currentMusic.source.time = Math.Max(position, 0);
                    currentMusic.source.Play();
                }
            }
        }
    }

    public float GetCurrentTimePosition()
    {
        if(currentMusic == null)
        {
            return -1;
        }
        else
        {
            return currentMusic.source.time;
        }
    }

    public void Stop()
    {
        if (currentMusic != null)
        {
            currentMusic.source.Stop();
        }
    }

    public void SetVolume(float volume)
    {
        mainVolume = volume;
        UpdateSound();
    }

    private void UpdateSound()
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = s.volume * mainVolume;
        }
    }
}
