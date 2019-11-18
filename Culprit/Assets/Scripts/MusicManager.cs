using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioBG;

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
        audioBG.Stop();
        if (!audioBG.isPlaying && muteBGMusic == false)
        {
            FadeSoundOn(audioBG, 1.5f, 0f, 0.5f);
            audioBG.clip = AudioMode2["0"];
            audioBG.PlayDelayed(1f);
            audioBG.loop = true;
            audioBG.Play();
        }
    }
    public void InGameMusic(string Level)
    {
        audioBG.Stop();
        if (!audioBG.isPlaying && muteBGMusic == false)
        {
            FadeSoundOn(audioBG, 1.5f, 0f, 0.5f);
            audioBG.clip = AudioMode2[Level];
            audioBG.PlayDelayed(1f);
            audioBG.loop = true;
            audioBG.Play();
        }
    }


    //------------------------------------------------------------------------------------------------
    public void StopBGMusic()
    {
        audioBG.Stop();
    }
    public void PauseBGMusic()
    {
        audioBG.Pause();
    }

    public void UnPauseBGMusic()
    {
        audioBG.UnPause();
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
        audioBG.mute = true;
    }

    public void UnMuteAllMusic()
    {
        audioBG.mute = false;
    }
}
