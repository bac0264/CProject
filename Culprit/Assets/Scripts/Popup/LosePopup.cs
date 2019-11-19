using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LosePopup : BasePopup
{
    public static LosePopup instance;
    public UnitStage unitStage;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
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
    }
    public override void Try()
    {
        if (SoundManager.instance != null) SoundManager.instance.UI_button_Click();
        unitStage = ButtonStageManager.instance.unitStage;
        Debug.Log(unitStage.unit);
        if (unitStage.unit != null)
        {
            unitStage.unit.Try();
        }
        HidePopup();
    }
}
