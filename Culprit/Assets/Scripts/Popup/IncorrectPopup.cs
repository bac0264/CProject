using UnityEngine;
using System.Collections;

public class IncorrectPopup : BasePopup
{
    public static IncorrectPopup instance;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public override void Home()
    {
        base.Home();
    }
    public override void ShowPopup()
    {
        if (SoundManager.instance != null) SoundManager.instance.UI_effect_Wrong();
        base.ShowPopup();
    }
    public override void HidePopup()
    {
        if (SoundManager.instance != null) SoundManager.instance.UI_button_Click();
        base.HidePopup();
        if (PickupCorrectAns.instance != null) PickupCorrectAns.instance.RUN = false;
    }
    public override void Try()
    {
        if (SoundManager.instance != null) SoundManager.instance.UI_button_Click();
        base.Try();

    }
    public override void Next()
    {
        if (SoundManager.instance != null) SoundManager.instance.UI_button_Click();
    }
}
