﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonStageManager : MonoBehaviour
{
    public static ButtonStageManager instance;
    public ButtonPickupMode1 btnPickup;
    public Camera mainCam;
    public Camera subCamm_1;
    public Stage stage;
    public UnitStage unitStage;
    public GameObject Mode2Cotnainer;
    public Animator backAnimator;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    private void OnValidate()
    {
        if (btnPickup == null) btnPickup = FindObjectOfType<ButtonPickupMode1>();
    }
    public void TurnOn_MainCam()
    {
        StartCoroutine(_TurnOn_MainCam());
    }
    IEnumerator _TurnOn_MainCam()
    {
        backAnimator.Play("Click");
        yield return new WaitForSeconds(KeySave.TIME_BACK);
        HideAllPopup();
        mainCam.gameObject.SetActive(true);
        subCamm_1.gameObject.SetActive(false);
        if (unitStage != null)
        {
            unitStage.Hide();
            //unitStage.unit = null;
            //unitStage. = null;
        }
        UnactiveBtn();
        backAnimator.Rebind();
    }
    public void TurnOn_Subcam(UnitStage unit)
    {
        subCamm_1.gameObject.SetActive(true);
        mainCam.gameObject.SetActive(false);
        unitStage = unit;
        if (unitStage.unit is UnitMode1)
        {
            Mode2Cotnainer.SetActive(false);
        }
        else
        {
            // Load Data for UnitMode2 & SetupBtn && Show Question
            unitStage.unit.LoadData();
            SetupBtnMode();
            Mode2Cotnainer.SetActive(true);
            if (PopupFactory.instance != null) PopupFactory.instance.GetPopup(BasePopup.TypeOfPopup.PO_Question);
        }
        btnPickup.AddBtns(unitStage);
    }
    public void SetupStageContainer(Stage stage)
    {
        this.stage = stage;
    }
    // Active and Unactive BtnAsk
    #region

    public void ActivePickupBtn()
    {
        btnPickup.ActivePickupBtn();

    }
    public void UnactiveBtn()
    {
        btnPickup.UnactiveBtn();
    }
    #endregion
    // Button Next Try of Popup
    #region
    public void HideAllPopup()
    {
        if (PopupFactory.instance != null) PopupFactory.instance.HideAllPopup();
    }

    #endregion
    // Popup
    #region
    public void ShowPopup(Unit unit)
    {
        if (unit.isWin)
        {
            if (PopupFactory.instance != null) PopupFactory.instance.GetPopup(BasePopup.TypeOfPopup.PO_Win);
        }
        else
        {
            if (PopupFactory.instance != null) PopupFactory.instance.GetPopup(BasePopup.TypeOfPopup.PO_Lose);
        }
    }
    #endregion
    // Mode 2
    public void SetupBtnMode()
    {
        if (unitStage != null && unitStage.unit != null && unitStage.unit is UnitMode2)
        {
            UnitMode2 unit = unitStage.unit as UnitMode2;
            ButtonPickupMode2.instance.SetupBtnDelegate(unit);
        }
    }
}
