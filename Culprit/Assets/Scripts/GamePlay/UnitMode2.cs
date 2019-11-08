﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UnitMode2 : Unit
{
    public List<Button> correctAnswerBtns;
    public Transform containerCorrectAnswersBtn;
    //  public bool[] checks;
    public int MaxIndexScene;
    public int CurIndexScene;
    public override void OnValidate()
    {
        base.OnValidate();
        if (correctAnswerBtns.Count == 0)
        {
            for (int i = 0; i < containerCorrectAnswersBtn.childCount; i++)
            {
                correctAnswerBtns.Add(containerCorrectAnswersBtn.GetChild(i).GetComponent<Button>());
            }
        }
        //if (checks.Length == 0)
        //{
        //    checks = new bool[4];
        //}
    }
    public override void LoadData()
    {
        CurIndexScene = 0;
        SaveLoadData.LoadDataUnitStage(indexStage, indexUnit, ref MaxIndexScene, ref isWin);
    }
    public override void SaveData()
    {
        SaveLoadData.SaveDataUnitStage(indexStage, indexUnit, MaxIndexScene, isWin);
    }
    private void Awake()
    {

        for (int i = 0; i < correctAnswerBtns.Count; i++)
        {
            // correctAnswerBtns[i].onClick.RemoveAllListeners();
            correctAnswerBtns[i].onClick.AddListener(delegate { SetCorrectAnswerButton(); });
        }
    }
    public void SetCorrectAnswerButton()
    {
        Correct();
    }

    // Show popup if incorrect
    public void Incorrect()
    {
        if (PickupCorrectAns.instance != null)
        {
            PickupCorrectAns.instance.RunPickup();
            PickupCorrectAns.instance.ISCORRECT = false;
        }
    }
    public void Correct()
    {
        // Run animation -> show popup
        if (PickupCorrectAns.instance != null)
        {
            PickupCorrectAns.instance.RunPickup();
            PickupCorrectAns.instance.ISCORRECT = true;
        }
    }
    public void OpenScene()
    {
        if (MaxIndexScene > correctAnswerBtns.Count - 1)
        {
            int temp = MaxIndexScene;
            MaxIndexScene = correctAnswerBtns.Count - 1;
            if (CurIndexScene == temp) CurIndexScene = MaxIndexScene;
            ButtonPickupMode2.instance.CloseBtn(MaxIndexScene);
            isWin = true;
            IsWin();
        }
        else if (MaxIndexScene <= 0)
        {
            return;
        }
        else
        {
            ButtonPickupMode2.instance.CloseBtn(MaxIndexScene - 1);
            ButtonPickupMode2.instance.OpenBtn(MaxIndexScene);
            correctAnswerBtns[MaxIndexScene - 1].gameObject.SetActive(false);
            correctAnswerBtns[MaxIndexScene].gameObject.SetActive(true);
            if (PopupContainer.instance != null) PopupContainer.instance.ShowQuestionPopup();
        }
        SaveData();
    }
    public override void Next()
    {
        if (CurIndexScene < MaxIndexScene)
        {
            CurIndexScene++;
            ButtonPickupMode2.instance.SetBtnSceneDisplay(this, CurIndexScene);
            if (PopupContainer.instance != null) PopupContainer.instance.ShowQuestionPopup();
        }
        else
        {
            MaxIndexScene++;
            CurIndexScene = MaxIndexScene;
            OpenScene();
        }
    }
    public override void IsWin()
    {
        if (isWin)
        {
            int curIndexUnit = SaveLoadData.LoadDataStage(indexStage);
            if (curIndexUnit <= indexUnit)
            {
                SaveLoadData.SaveDataStage(indexStage, indexUnit + 1);
                if (ButtonStageManager.instance != null && StageManager.instance != null)
                {
                    UnitStage unitStage = ButtonStageManager.instance.unitStage;
                    ButtonStageManager.instance.stage.LoadImageForAllUnitStage();
                    StageManager.instance.NextLevel(unitStage);
                }
            }
            else
            {
                if (ButtonStageManager.instance != null && StageManager.instance != null)
                {
                    UnitStage unitStage = ButtonStageManager.instance.unitStage;
                    ButtonStageManager.instance.stage.LoadImageForAllUnitStage();
                    if (StageManager.instance.NextLevel(unitStage))
                    {
                        ButtonStageManager.instance.SetupBtnMode();
                        if (PopupContainer.instance != null) PopupContainer.instance.ShowQuestionPopup();
                    }
                }
                // }
            }
        }
    }
    public override void Try()
    {
    }
    //public void 
}
