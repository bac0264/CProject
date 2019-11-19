using UnityEngine;
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
        if (SoundManager.instance != null) SoundManager.instance.UI_button_Click();
        StartCoroutine(_TurnOn_MainCam());
    }
    IEnumerator _TurnOn_MainCam()
    {
        if (SoundManager.instance != null) SoundManager.instance.StopAllSound();
        if (MusicManager.instance != null) MusicManager.instance.MenuStartGameMusic();
        backAnimator.Play("Click");
        HideAllPopup();
        yield return new WaitForSeconds(KeySave.TIME_BACK);
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
    public void Home()
    {
        if (MusicManager.instance != null) MusicManager.instance.MenuStartGameMusic();
        HideAllPopup();
        if (unitStage != null)
        {
            unitStage.Hide();
            //unitStage.unit = null;
            //unitStage. = null;
        }
        UnactiveBtn();
        mainCam.gameObject.SetActive(true);
        subCamm_1.gameObject.SetActive(false);
    }
    public void TurnOn_Subcam(UnitStage unit)
    {
        if (SoundManager.instance != null) SoundManager.instance.UI_effect_Pick();
        subCamm_1.gameObject.SetActive(true);
        mainCam.gameObject.SetActive(false);
        unitStage = unit;
        if (unitStage.unit is UnitMode1)
        {
            if (MusicManager.instance != null) MusicManager.instance.StopBGMusic();
            Mode2Cotnainer.SetActive(false);
        }
        else
        {
            if (MusicManager.instance != null) MusicManager.instance.InGameMusic((unit._index + 1).ToString());
            // Load Data for UnitMode2 & SetupBtn && Show Question
            unitStage.unit.LoadData();
            SetupBtnMode();
            Mode2Cotnainer.SetActive(true);
            if (PopupFactory.instance != null) PopupFactory.instance.ShowPopup(BasePopup.TypeOfPopup.PO_Question);
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
            if (PopupFactory.instance != null) PopupFactory.instance.ShowPopup(BasePopup.TypeOfPopup.PO_Win);
        }
        else
        {
            if (PopupFactory.instance != null) PopupFactory.instance.ShowPopup(BasePopup.TypeOfPopup.PO_Lose);
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
