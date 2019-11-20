using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HintPopup : BasePopup
{
    public static HintPopup instance;


    public Text hint;

    public UnitStage unitStage;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public override void ShowPopup()
    {
        unitStage = ButtonStageManager.instance.unitStage;
        if (unitStage != null && unitStage.unit != null && unitStage.unit is UnitMode2)
        {
            UnitMode2 unitMode2 = unitStage.unit as UnitMode2;
            hint.text = LevelDataManager.instance.GetHint(unitMode2.indexStage, unitMode2.indexUnit, unitMode2.CurIndexScene);
            if (FireBaseEventManager.instance != null)
            {
                FireBaseEventManager.instance.P_Hint_Level(unitMode2.indexUnit, unitMode2.CurIndexScene);
            }
        }
        base.ShowPopup();
    }
    public override void HidePopup()
    {
        if (SoundManager.instance != null) SoundManager.instance.UI_button_Click();
        base.HidePopup();
    }
}
