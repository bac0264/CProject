using UnityEngine;
using System.Collections;

public class SettingPopup : BasePopup
{
    public static SettingPopup instance;
    public Animator ani;
    private void Awake()
    {
        if (instance == null) instance = this;
        ani = GetComponent<Animator>();
    }
    public void RunAniFadeOut()
    {
        ani.Play("FadeOut");
    }
    public override void ShowPopup()
    {
        base.ShowPopup();
        ani.Play("FadeIn");
    }
    public void TurnOnSound()
    {

    }
    public void TurnOffSound()
    {

    }
    public void TurnOnMusic()
    {

    }
    public void TurnOffMusic()
    {

    }
    public void Language()
    {

    }
}
