﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuestionPopup : BasePopup
{
    public static QuestionPopup instance;


    public Text question;

    public UnitStage unitStage;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public override void ShowPopup()
    {
        unitStage = ButtonStageManager.instance.unitStage;
        if(unitStage != null && unitStage.unit != null && unitStage.unit is UnitMode2)
        {
            UnitMode2 unitMode2 = unitStage.unit as UnitMode2;
            question.text = LevelDataManager.instance.GetQuestion(unitMode2.indexStage, unitMode2.indexUnit, unitMode2.CurIndexScene);
        }
        base.ShowPopup();
    }
}
