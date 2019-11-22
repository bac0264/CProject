using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Animator ani;
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    private void Start()
    {
        if (PlayerPrefs.GetInt(KeySave.SOUND, 0) == 0)
        {
            if (SoundManager.instance != null) SoundManager.instance.UnMuteAllSound();
        }
        else
        {
            if (SoundManager.instance != null) SoundManager.instance.MuteAllSound();
        }
        if (PlayerPrefs.GetInt(KeySave.MUSIC, 0) == 0)
        {
            if (MusicManager.instance != null) MusicManager.instance.UnMuteAllMusic();
        }
        else
        {
            if (MusicManager.instance != null) MusicManager.instance.MuteAllMusic();
        }
    }
    private void OnValidate()
    {
        if (ani == null) ani = GetComponent<Animator>();
    }
    public void ClickedStages()
    {
        if (FireBaseEventManager.instance != null)
        {
            FireBaseEventManager.instance.MENU_Taptoplay();
        }
        if (SoundManager.instance != null) SoundManager.instance.UI_button_Click();
        ani.Play("Hide");
    }
    public void NextScene()
    {
        SceneManager.LoadScene("MenuToStage");
    }
    public void ClickSetting()
    {
        if (FireBaseEventManager.instance != null)
        {
            FireBaseEventManager.instance.MENU_BtnSetting();
        }
        if (PopupFactory.instance != null) PopupFactory.instance.ShowPopup(BasePopup.TypeOfPopup.PO_Setting);
    }
}
