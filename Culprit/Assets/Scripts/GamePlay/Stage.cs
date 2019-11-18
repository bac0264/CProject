using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.GamePlay;
using EnhancedUI.EnhancedScroller;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Assets.Scripts.Interface;
using EnhancedScrollerDemos.SuperSimpleDemo;

public class Stage : CellView, IShowStage, IPointerClickHandler, IHide, IOpen
{
    public event Action<UnitStage> OnRightClickEvent;
    public event Action<Stage> OnRightClickStageEvent;

    //  public UnitStage[] _unitList;
    public BlockUnitStage[] _blockList;
    public Image stageImage;

    public Text type;
    public int index;
    public int amountOfUnitStage;

    public override void SetData(Data data)
    {
        base.SetData(data);
        if (data is DataStage)
        {
            DataStage dataStage = data as DataStage;
            index = dataStage.indexStage;
            amountOfUnitStage = dataStage.amountUnitStage;
        }
    }
    public UnitStage GetUnitStage(int indexUnitStage)
    {
        int temp = KeySave.Get_Index_Block(indexUnitStage);
        if ((indexUnitStage) < amountOfUnitStage && temp < _blockList.Length)
        {
            UnitStage unitStage = _blockList[KeySave.Get_Index_Block(indexUnitStage)]
                .unitstageList[KeySave.Get_Index_UnitStage(indexUnitStage)];
            unitStage.unit = LoadUnitOnvalidate.instance.GetUnitFromResources(index, unitStage._index);
            return unitStage;
        }
        return null;
    }
    public UnitStage GetNextUnitStage(int indexUnitStage)
    {
        int next = indexUnitStage + 1;
        if (next < amountOfUnitStage)
        {
            UnitStage unitStage = _blockList[KeySave.Get_Index_Block(next)]
      .unitstageList[KeySave.Get_Index_UnitStage(next)];
            unitStage.unit = LoadUnitOnvalidate.instance.GetUnitFromResources(index, unitStage._index);
            if (unitStage.unit != null) return unitStage;
            return null;
        }
        return null;
    }
    // Pick unit stage
    #region
    public void PickUnitStage(UnitStage unitstage)
    {

        if (unitstage != null)
        {
            Unit unit = LoadUnitOnvalidate.instance.GetUnitFromResources(index, unitstage._index);
            if (unit != null)
            {
                unitstage.LoadUnit(unit);
                // HideAll(unitstage);
                unitstage.ShowStage();
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Left)
        {
            if (OnRightClickStageEvent != null)
            {
                OnRightClickStageEvent(this);
            }
        }
    }
    #endregion
    // Hide All unitStage didnt pick
    public void HideAll(UnitStage unitstage)
    {
        //foreach (UnitStage unitStage in _unitList)
        //{
        //    if (unitStage._index == unitstage._index)
        //    {
        //        unitStage.gameObject.SetActive(true);
        //    }
        //    else
        //    {
        //        unitStage.gameObject.SetActive(false);
        //    }
        //}
    }
    public void ShowStage()
    {
        if (ButtonStageManager.instance != null)
            ButtonStageManager.instance.SetupStageContainer(this);
        Hide();
        // OpenAllUnitStage();
    }

    // Hide & Open Stage and unitStage
    #region

    // Hide Stage
    public void Hide()
    {
        stageImage.enabled = false;
    }
    // Open Stage   
    public void Open()
    {
        stageImage.enabled = true;
    }

    public void OpenAllUnitStage()
    {
        for (int i = 0 ; i < _blockList.Length; i++)
        {
            for (int j = 0; j < _blockList[i].unitstageList.Length; j++)
            {
                _blockList[i].unitstageList[i].ActiveUnitStage(index);
            }
        }
    }
    public void LoadImageForAllUnitStage()
    {
        int i = 0;
        for (; i < _blockList.Length; i++)
        {
            for (int j = 0; j < _blockList[i].unitstageList.Length; j++)
            {
                _blockList[i].unitstageList[j].LoadImage(index);
            }
        }
    }
    public void HideAllUnitStage()
    {
        for (int i = 0; i < _blockList.Length; i++)
        {
            for (int j = 0; j < _blockList[i].unitstageList.Length; j++)
            {
                _blockList[i].unitstageList[i].UnactiveUnitStage();
            }
        }
        Open();
    }
    #endregion
    public void Back()
    {
        OpenAllUnitStage();
        Hide();
        StageManager.instance.SetupBtn(1);
    }

    // Onvalidate
    #region
    public Transform unitStageContainer;
    private void OnValidate()
    {
        if (type == null) type = GetComponentInChildren<Text>();
        if (stageImage == null) stageImage = GetComponent<Image>();
    }
    #endregion
    public void LoadUnit()
    {
        UnitEnhance unitEnhance = UnitEnhance.instance;
        if (unitEnhance != null)
        {
            unitEnhance.LoadData(amountOfUnitStage, index);
            unitStageContainer = unitEnhance.scroller.GetContainer().transform;
            unitStageContainer.gameObject.SetActive(true);

            for (int g = 0; g < unitStageContainer.childCount; g++)
            {
                unitStageContainer.GetChild(g).gameObject.SetActive(true);
            }
            _blockList = unitStageContainer.GetComponentsInChildren<BlockUnitStage>();
            SetupEvent();
        }
    }
    public void SetupEvent()
    {
        OnRightClickEvent += PickUnitStage;
        for (int i = 0; i < _blockList.Length; i++)
        {
            for (int j = 0; j < _blockList[i].unitstageList.Length; j++)
            {
                _blockList[i].unitstageList[j].OnRightClickEvent += OnRightClickEvent;
            }
        }
    }
    public void RemoveEvents()
    {
        for (int i = 0; i < _blockList.Length; i++)
        {
            for (int j = 0; j < _blockList[i].unitstageList.Length; j++)
            {
                _blockList[i].unitstageList[j].OnRightClickEvent -= OnRightClickEvent;
            }
        }
    }

    // Tutorial
    public void Step_2_TutorialUnitStagePickup()
    {
        PickUnitStage(GetUnitStage(0));
    }
}
