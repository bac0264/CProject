using UnityEngine;
using System.Collections;

public class SettingPopup : BasePopup
{
    public static SettingPopup instance;
    public GameObject turnOnMusic;
    public GameObject turnOffMusic;
    public GameObject turnOnSound;
    public GameObject turnOffSound;
    public Animator ani;
    public Snap snap;
    private void OnValidate()
    {
        if (snap == null) snap = FindObjectOfType<Snap>();
    }
    private void Awake()
    {
        if (instance == null) instance = this;
        ani = GetComponent<Animator>();
        if (PlayerPrefs.GetInt(KeySave.SOUND, 0) == 0)
        {
            TurnOnSound();
            if (SoundManager.instance != null) SoundManager.instance.UnMuteAllSound();
        }
        else
        {
            TurnOffSound();
            if (SoundManager.instance != null) SoundManager.instance.MuteAllSound();
        }
        if (PlayerPrefs.GetInt(KeySave.MUSIC, 0) == 0)
        {
            TurnOnMusic();
            if (MusicManager.instance != null) MusicManager.instance.UnMuteAllMusic();
        }
        else
        {
            TurnOffMusic();
            if (MusicManager.instance != null) MusicManager.instance.MuteAllMusic();
        }
    }
    public void RunAniFadeOut()
    {
        if (SoundManager.instance != null) SoundManager.instance.UI_button_Click();
        ani.Play("FadeOut");
    }
    public override void ShowPopup()
    {
        if (SoundManager.instance != null) SoundManager.instance.UI_button_Click();
        TextScript[] texts = GetComponentsInChildren<TextScript>();
        TextmeshScript[] textmeshs = GetComponentsInChildren<TextmeshScript>();
        if (texts.Length > 0)
        {
            foreach (TextScript _text in texts) _text.UpdateText();
        }
        if (textmeshs.Length > 0)
        {
            foreach (TextmeshScript _text in textmeshs) _text.UpdateText();
        }
        base.ShowPopup();
        ani.Play("FadeIn");
    }
    public void SoundBtn()
    {
        if (SoundManager.instance != null) SoundManager.instance.UI_effect_Pick();
        if (PlayerPrefs.GetInt(KeySave.SOUND) == 1)
        {
            TurnOnSound();
            if (SoundManager.instance != null) SoundManager.instance.UnMuteAllSound();
            PlayerPrefs.SetInt(KeySave.SOUND, 0);
        }
        else
        {
            if (FireBaseEventManager.instance != null)
            {
                FireBaseEventManager.instance.MENU_OffSound();
            }
            TurnOffSound();
            if (SoundManager.instance != null) SoundManager.instance.MuteAllSound();
            PlayerPrefs.SetInt(KeySave.SOUND, 1);
        }
    }
    public void MusicBtn()
    {
        if (SoundManager.instance != null) SoundManager.instance.UI_effect_Pick();
        if (PlayerPrefs.GetInt(KeySave.MUSIC) == 1)
        {
            TurnOnMusic();
            if (MusicManager.instance != null) MusicManager.instance.UnMuteAllMusic();
            PlayerPrefs.SetInt(KeySave.MUSIC, 0);
        }
        else
        {
            if (FireBaseEventManager.instance != null)
            {
                FireBaseEventManager.instance.MENU_OffMuic();
            }
            TurnOffMusic();
            if (MusicManager.instance != null) MusicManager.instance.MuteAllMusic();
            PlayerPrefs.SetInt(KeySave.MUSIC, 1);
        }
    }
    public void TurnOnSound()
    {
        turnOnSound.SetActive(true);
        turnOffSound.SetActive(false);
    }
    public void TurnOffSound()
    {
        turnOnSound.SetActive(false);
        turnOffSound.SetActive(true);
    }
    public void TurnOnMusic()
    {
        turnOnMusic.SetActive(true);
        turnOffMusic.SetActive(false);
    }
    public void TurnOffMusic()
    {
        turnOnMusic.SetActive(false);
        turnOffMusic.SetActive(true);
    }
    public void Language()
    {
        if (PlayerPrefs.GetInt(KeySave.LANGUAGE) == 0)
        {
            PlayerPrefs.SetInt(KeySave.LANGUAGE, 1);
        }
        else
        {
            PlayerPrefs.SetInt(KeySave.LANGUAGE, 0);
        }
        if (LevelDataManager.instance != null) LevelDataManager.instance.GetDataFromServer();
    }
    public void Vietnamese()
    {
        if (FireBaseEventManager.instance != null)
        {
            FireBaseEventManager.instance.MENU_Language();
        }
        if (SoundManager.instance != null) SoundManager.instance.UI_effect_Pick();
        PlayerPrefs.SetInt(KeySave.LANGUAGE, 0);
        if (LevelDataManager.instance != null) LevelDataManager.instance.GetDataFromServer();
        snap.UpdateBtn();

    }
    public void English()
    {
        if (FireBaseEventManager.instance != null)
        {
            FireBaseEventManager.instance.MENU_Language();
        }
        if (SoundManager.instance != null) SoundManager.instance.UI_effect_Pick();
        PlayerPrefs.SetInt(KeySave.LANGUAGE, 1);
        if (LevelDataManager.instance != null) LevelDataManager.instance.GetDataFromServer();
        snap.UpdateBtn();
    }
}
