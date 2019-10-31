using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource[] audioFX;

    public AudioClip PopupOpen;
    public AudioClip Select;
    public AudioClip Confirm;


    public bool mute;
    public static SoundManager instance;

    // Start is called before the first frame update
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
    }
    public void SelectBtn()
    {
        audioFX[0].PlayOneShot(Select, 1f);
    }
    public void PopupBtn()
    {
        audioFX[0].PlayOneShot(PopupOpen, 1f);
    }

    public void ConfirmBtn()
    {
        audioFX[0].PlayOneShot(Confirm, 1f);
    }

    //--------------------------------------------

 

    //-------------------------------------------------------------------
    public void StopAllSound()
    {
        for (int i = 0; i < audioFX.Length; i++)
        {
            audioFX[i].Stop();
        }
    }

    public void MuteAllSound()
    {
        for (int i = 0; i < audioFX.Length; i++)
        {
            audioFX[i].mute = true;
        }
    }

    public void UnMuteAllSound()
    {
        for (int i = 0; i < audioFX.Length; i++)
        {
            audioFX[i].mute = false;
        }
    }
}
