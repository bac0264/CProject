﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitMode1 : Unit
{
    public Animator ani;
    public Transform btnContainer;
    public List<Transform> AskBtns;
    public List<int> results = new List<int>();
    public override void OnValidate()
    {
        base.OnValidate();
        if (ani == null) ani = GetComponent<Animator>();
        if (AskBtns.Count == 0)
        {
            for (int i = 0; i < btnContainer.childCount; i++)
            {
                AskBtns.Add(btnContainer.GetChild(i).GetComponent<Transform>());
            }
        }
    }
    public override void Try()
    {
        ani.Rebind();
    }
    public void Lose()
    {
        ani.Play("result_lose");
    }

    public void Win()
    {
        ani.Play("result_win");
    }
    public bool IsWin(int index)
    {
        if (index == 1)
        {
            Win();
            isWin = true;
            return true;
        }
        isWin = false;
        Lose();
        return false;
    }
    public int GetResult(int btnIndex)
    {
        if (btnIndex < 0 || AskBtns.Count == 0 || btnIndex >= AskBtns.Count) return 0;
        return results[btnIndex];
    }
    // Set Event in animation
    #region
    public void ActiveBtn()
    {
        if (ButtonStageManager.instance != null)
        {
            ButtonStageManager.instance.ActivePickupBtn();
        }
        if (PopupFactory.instance != null) PopupFactory.instance.ShowPopup(BasePopup.TypeOfPopup.PO_QuestionMode1);
    }
    public override void ShowPopup()
    {
        base.ShowPopup();
        if (QuestionMode1Popup.instance != null) QuestionMode1Popup.instance.HidePopup();
    }
    public void EventWin()
    {
        int curIndexUnit = SaveLoadData.LoadDataStage(indexStage);
        if (curIndexUnit <= indexUnit)
        {
            Debug.Log(indexUnit);
            SaveLoadData.SaveDataStage(indexStage, indexUnit + 1);
            ButtonStageManager.instance.stage.LoadImageForAllUnitStage();
        }
    }
    #endregion
}
