using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.GamePlay;
using System;
using Assets.Scripts.Interface;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using EnhancedScrollerDemos.SuperSimpleDemo;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;
    public Sprite[] _spriteList;
    public string[] titles;
    public Stage[] _stageList;
    public event Action<Stage> OnRightClickStageEvent;
    public Button[] btns;
    public Stage curStage;
    public Image imageOfUnitStageManager;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public bool NextLevel(UnitStage cur)
    {
        if (cur.unit.indexStage < _stageList.Length)
        {
            Stage curStage = _stageList[cur.unit.indexStage];
            UnitStage curUnitStage = curStage.GetNextUnitStage(cur.unit.indexUnit);
            // if unitstage belong to curStage -> show, else -> next stage
            if (curUnitStage != null)
            {
                cur.Hide();
                curUnitStage.ShowStage();
                ButtonStageManager.instance.unitStage = curUnitStage;
                ButtonStageManager.instance.stage = curStage;
                return true;
            }
            else
            {
                ButtonStageManager.instance.TurnOn_MainCam();
                return false;
            }
        }
        return false;
    }
    // Pickup, Open && Hide All Stage
    #region
    public void PickStage(Stage Stage)
    {
        imageOfUnitStageManager.enabled = true;
        curStage = Stage;
        Stage.LoadUnit();
        HideAll(Stage);
        Stage.ShowStage();
        SetupBtn(1);
        if (StageEnhance.instance != null)
            StageEnhance.instance.scroller.GetContainer().SetActive(false);
        if (UnitEnhance.instance != null)
            UnitEnhance.instance.scroller.GetContainer().SetActive(true);
    }
    // Hide all Stage except picked Stage
    public void HideAll(Stage Stage)
    {
        foreach (Stage stage in _stageList)
        {
            if (stage.index != Stage.index) stage.gameObject.SetActive(false);
            else stage.gameObject.SetActive(true);
        }
    }
    public void OpenAllStage()
    {
        foreach (Stage stage in _stageList)
        {
            stage.gameObject.SetActive(true);
            stage.HideAllUnitStage();
        }
    }
    #endregion
    public void Back()
    {
        OpenAllStage();
        imageOfUnitStageManager.enabled = false;
        btns[0].gameObject.SetActive(true);
        btns[1].gameObject.SetActive(false);
        if (curStage != null) curStage.RemoveEvents();
        if (StageEnhance.instance != null)
            StageEnhance.instance.scroller.GetContainer().SetActive(true);
        if (UnitEnhance.instance != null)
            UnitEnhance.instance.scroller.GetContainer().SetActive(false);
    }
    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void SetupBtn(int index)
    {
        for (int i = 0; i < btns.Length; i++)
        {
            if (i == index)
            {
                btns[i].gameObject.SetActive(true);
            }
            else
                btns[i].gameObject.SetActive(false);
        }
    }
    // Load Onvalidate
    #region
    // Thread: Enhance Scroller create object attaching Stage Script -> Stage Manager get Stage array.
    // Thread: When picking up Stage -> Show all unitStage ( get recycled ) -> Picking unitstage to load unit 
    public void LoadUnit(Unit[] unitList)
    {
        for (int g = 0; g < transform.childCount; g++)
        {
            transform.GetChild(g).gameObject.SetActive(true);
        }
        _stageList = GetComponentsInChildren<Stage>();
        for (int i = 0; i < _stageList.Length && i < _spriteList.Length; i++)
        {
            _stageList[i].gameObject.GetComponent<Image>().sprite = _spriteList[i];
            _stageList[i].type.text = titles[i];
        }

        //_stageList = GetComponentsInChildren<Stage>();
    }
    public void SetupEvent()
    {
        LoadUnit(LoadUnitOnvalidate.instance.unitList);
        OnRightClickStageEvent += PickStage;
        foreach (Stage stage in _stageList)
        {
            stage.OnRightClickStageEvent += OnRightClickStageEvent;
        }
    }
    #endregion

}
