using Assets.Scripts.GamePlay;
using Assets.Scripts.Interface;
using EnhancedScrollerDemos.SuperSimpleDemo;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnitStage : MonoBehaviour, IShowStage, IPointerClickHandler, IHide, IOpen
{
    public event Action<UnitStage> OnRightClickEvent;

    private const int PASSED = 0;
    private const int CURRENT = 1;
    private const int HIDE = 2;
    public int _index;
    public bool _isPass;
    public bool _isOpen;

  //  public SpriteUnitStageSO unitSprite;
    public Unit unit;
    public GameObject[] spriteList;

    public Text level;
    public Image unitImage;
    public void SetData(Data data)
    {
        if (data is DataUnitStage)
        {
            DataUnitStage dataUnitStage = data as DataUnitStage;
            level.text = (dataUnitStage.indexUnitStage + 1).ToString();
            _index = dataUnitStage.indexUnitStage;
            LoadImage(dataUnitStage.indexStage);
        }
    }
    public void ShowStage()
    {
        Open();
        //  ShowStage();
        SetUpCamera();
    }
    // Open & Hide unit
    #region

    // Open unit
    public void Hide()
    {
        if (unit != null)
        {
            unit.gameObject.SetActive(false);
        }
    }
    // Hide unit
    public void Open()
    {
        if (unit != null)
        {
            unit.gameObject.SetActive(true);
        }
    }
    public void UnactiveUnitStage()
    {
        gameObject.SetActive(false);
    }
    public void ActiveUnitStage(int indexStage)
    {
        gameObject.SetActive(true);
        Hide();
    }
    #endregion
    public void LoadImage(int indexStage)
    {
        int curUnitStage = SaveLoadData.LoadDataStage(indexStage);
        if (_index < curUnitStage)
        {
            enabled = true;
            level.gameObject.SetActive(true);
            SetupImage(PASSED);
        }
        else if (_index == curUnitStage)
        {
            enabled = true;
            level.gameObject.SetActive(true);
            SetupImage(CURRENT);
        }
        else
        {
            enabled = false;
            level.gameObject.SetActive(false);
            SetupImage(HIDE);
        }
    }
    public void LoadUnit(Unit unit)
    {
        this.unit = unit;
        unit.gameObject.SetActive(false);
    }
    public void SetUpCamera()
    {
        if (ButtonStageManager.instance != null)
            ButtonStageManager.instance.TurnOn_Subcam(this);
    }
    public void SetupImage(int index)
    {
        for (int i = 0; i < spriteList.Length; i++)
        {
            if(index == i) spriteList[i].SetActive(true);
            else
            {
                spriteList[i].SetActive(false);
            }
        }
    }
    // Onvalidate
    #region
    private void OnValidate()
    {
        //if (unit == null)
        //{
        //    unit = GetComponentInChildren<Unit>();
        //    unit.gameObject.SetActive(false);
        //}
        if (unitImage == null) unitImage = GetComponent<Image>();
        if (level == null) level = GetComponentInChildren<Text>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Left)
        {
            if (OnRightClickEvent != null)
            {
                OnRightClickEvent(this);
            }
        }
    }
    public void LoadUnitOnvalidate()
    {
        level.text = (_index + 1).ToString();
        this.gameObject.SetActive(true);
    }
    #endregion
}
