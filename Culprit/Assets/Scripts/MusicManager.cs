using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource[] audioBG;
    public MusicMode2Container musicMode2;
    public Dictionary<string, AudioClip> AudioMode2 = new Dictionary<string, AudioClip>();
    [Header("---------------------BG Music Menu----------------------")]

    public bool muteBGMusic;
    public static MusicManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        LoadData();

        MenuStartGameMusic();
    }
    public void LoadData()
    {
        AudioClip[] _AudioMode2 = Resources.LoadAll<AudioClip>("AudioMode2");
        foreach (AudioClip clip in _AudioMode2)
        {
            AudioMode2.Add(clip.name, clip);
        }
    }
    public void MenuStartGameMusic()
    {
        try
        {
            FadeSoundOff(audioBG[1], 1.5f, 0f, 0.5f);
            if (muteBGMusic == false)
            {
                FadeSoundOn(audioBG[0], 1.5f, 0f, 0.5f);
                audioBG[0].clip = AudioMode2["0"];
                audioBG[0].PlayDelayed(1f);
                audioBG[0].loop = true;
                audioBG[0].Play();
            }
        }
        catch (Exception e)
        {
            print(e);
        }
    }
    public void InGameMusic(string Level)
    {
        try
        {
            string soundCode = musicMode2.GetMusicMode2((int.Parse(Level) + 1).ToString()).SoundCode;
            FadeSoundOff(audioBG[0], 1.5f, 0f, 0.5f);
            if (muteBGMusic == false)
            {
                FadeSoundOn(audioBG[1], 1.5f, 0f, 0.5f);
                audioBG[1].clip = AudioMode2[soundCode];
                audioBG[1].PlayDelayed(1f);
                audioBG[1].loop = true;
                audioBG[1].Play();
            }
        }catch(Exception e)
        {
            print(e);
        }
    }

    //------------------------------------------------------------------------------------------------
    public void StopBGMusic()
    {
        for (int i = 0; i < audioBG.Length; i++)
        {
            audioBG[i].Stop();
        }
    }
    public void PauseBGMusic()
    {
        for (int i = 0; i < audioBG.Length; i++)
        {
            audioBG[i].Pause();
        }
    }

    public void UnPauseBGMusic()
    {
        for (int i = 0; i < audioBG.Length; i++)
        {
            audioBG[i].UnPause();
        }
    }

    public void FadeSoundOn(AudioSource audioSrc, float fadeTime, float minVolume, float maxVolume)
    {
        StartCoroutine(_FadeSoundOn(audioSrc, fadeTime, minVolume, maxVolume));
    }
    IEnumerator _FadeSoundOn(AudioSource audioSrc, float fadeTime, float minVolume, float maxVolume)
    {
        float t = minVolume;
        while (t < fadeTime * maxVolume)
        {
            yield return null;
            t += Time.deltaTime;
            audioSrc.volume = t / fadeTime;
        }
        yield break;
    }

    public void FadeSoundOff(AudioSource audioSrc, float fadeTime, float minVolume, float maxVolume)
    {
        StartCoroutine(_FadeSoundOff(audioSrc, fadeTime, minVolume, maxVolume));
    }
    IEnumerator _FadeSoundOff(AudioSource audioSrc, float fadeTime, float minVolume, float maxVolume)
    {
        float t = fadeTime * maxVolume;
        while (t > minVolume)
        {
            yield return null;
            t -= Time.deltaTime;
            audioSrc.volume = t / fadeTime;
            if (audioSrc.volume < 0.01f)
            {
                audioSrc.Stop();
            }
        }
        yield break;
    }

    public void MuteAllMusic()
    {
        for (int i = 0; i < audioBG.Length; i++)
        {
            audioBG[i].mute = true;
        }
    }

    public void UnMuteAllMusic()
    {
        for (int i = 0; i < audioBG.Length; i++)
        {
            audioBG[i].mute = false;
        }
    }
}
