using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UnitMode2 : Unit
{
    public List<Button> correctAnswerBtns;
    public Transform containerCorrectAnswersBtn;
    public bool[] checks;
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
        if (checks.Length == 0)
        {
            checks = new bool[4];
        }
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
        if (IncorrectPopup.instance == null) PopupContainer.instance.GetIncorrectPopup();
        if (IncorrectPopup.instance != null)
        {
            IncorrectPopup.instance.ShowPopup();
        }
    }
    public void Correct()
    {
        if (CorrectPopup.instance == null) PopupContainer.instance.GetCorrectPopupPrefab();
        if (CorrectPopup.instance != null)
        {
            CorrectPopup.instance.ShowPopup();
        }
    }
    public void OpenScene()
    {
        if (MaxIndexScene > correctAnswerBtns.Count - 1)
        {
            int temp = MaxIndexScene;
            MaxIndexScene = correctAnswerBtns.Count - 1;
            if (CurIndexScene == temp) CurIndexScene = MaxIndexScene;
            ButtonPickupScene.instance.CloseBtn(MaxIndexScene);
            checks[MaxIndexScene] = true;
            isWin = true;
            IsWin();
            return;
        }
        else if (MaxIndexScene <= 0)
        {
            return;
        }
        else
        {
            checks[MaxIndexScene - 1] = true;
            checks[MaxIndexScene] = false;
            ButtonPickupScene.instance.CloseBtn(MaxIndexScene - 1);
            ButtonPickupScene.instance.OpenBtn(MaxIndexScene);
            correctAnswerBtns[MaxIndexScene - 1].gameObject.SetActive(false);
            correctAnswerBtns[MaxIndexScene].gameObject.SetActive(true);
        }
    }
    public override void Next()
    {
        if (CurIndexScene < MaxIndexScene)
        {
            CurIndexScene++;
            ButtonPickupScene.instance.SetBtnSceneDisplay(this,CurIndexScene);
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
            int curIndexUnit = SaveLoadStageData.LoadDataStage(indexStage);
            if (curIndexUnit <= indexUnit)
            {
                SaveLoadStageData.SaveDataStage(indexStage, indexUnit + 1);
                if (ButtonStageManager.instance != null && StageManager.instance != null)
                {
                    UnitStage unitStage = ButtonStageManager.instance.unitStage;
                    ButtonStageManager.instance.stage.LoadImageForAllUnitStage();
                    StageManager.instance.NextLevel(unitStage);
                }
            }
            else
            {
                if (curIndexUnit >= LoadUnitOnvalidate.instance.GetAmountUnitStage(indexStage) && (indexUnit + 1) == curIndexUnit)
                {
                    ButtonStageManager.instance.TurnOn_MainCam();
                }
                else
                {
                    if (ButtonStageManager.instance != null && StageManager.instance != null)
                    {
                        UnitStage unitStage = ButtonStageManager.instance.unitStage;
                        ButtonStageManager.instance.stage.LoadImageForAllUnitStage();
                        StageManager.instance.NextLevel(unitStage);
                    }
                }
            }
        }
    }
    public override void Try()
    {
    }
    //public void 
}
