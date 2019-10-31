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
    public override void ShowPopup()
    {
        base.ShowPopup();
    }
    public override void HidePopup()
    {
        base.HidePopup();
    }
    public override void Try()
    {
        unitStage = ButtonStageManager.instance.unitStage;
        Debug.Log(unitStage.unit);
        if (unitStage.unit != null)
        {
            unitStage.unit.Try();
        }
        HidePopup();
    }
}
