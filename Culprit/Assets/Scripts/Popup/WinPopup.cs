using UnityEngine;
using System.Collections;

public class WinPopup : BasePopup
{
    public static WinPopup instance;
    public UnitStage unitStage;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public override void ShowPopup()
    {
        if (SoundManager.instance != null) SoundManager.instance.UI_effect_Correct();
        base.ShowPopup();
    }
    public override void HidePopup()
    {
        base.HidePopup();
    }
    public override void Try()
    {
        if (SoundManager.instance != null) SoundManager.instance.UI_button_Click();
        unitStage = ButtonStageManager.instance.unitStage;
        if (unitStage.unit != null)
        {
            unitStage.unit.Try();
        }
        HidePopup();
    }
    public override void Next()
    {
        if (SoundManager.instance != null) SoundManager.instance.UI_button_Click();
        unitStage = ButtonStageManager.instance.unitStage;
        Stage curStage = ButtonStageManager.instance.stage;
        if (StageManager.instance != null && unitStage.unit != null)
            StageManager.instance.NextLevel(unitStage,curStage);
        HidePopup();
    }
}
