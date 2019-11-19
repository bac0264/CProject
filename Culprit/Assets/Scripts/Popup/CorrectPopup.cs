using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CorrectPopup : BasePopup
{
    public static CorrectPopup instance;
    public UnitStage container;
    public Text Explanation;
    public Image spriteEvidence;
    public LevelEvidenceSprites spriteData;


    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public override void Home()
    {
        base.Home();
    }
    public override void ShowPopup()
    {
        if (SoundManager.instance != null) SoundManager.instance.UI_effect_Correct();
        Refresh();
        container = ButtonStageManager.instance.unitStage;
        if (container != null && container.unit != null && container.unit is UnitMode2)
        {
            UnitMode2 unitMode2 = container.unit as UnitMode2;
            Explanation.text = LevelDataManager.instance.GetAnswer(unitMode2.indexStage, unitMode2.indexUnit, unitMode2.CurIndexScene);
            spriteEvidence.sprite = spriteData.GetSprite(unitMode2.indexUnit, unitMode2.CurIndexScene);
        }
        base.ShowPopup();
        if(PlayerPrefs.GetInt(KeySave.HINT,0) == 1)
        {
            if (AdManager.Ins != null) AdManager.Ins.ShowVideo();
            PlayerPrefs.SetInt(KeySave.HINT, 0);
        }
        else
        {

        }
    }
    public override void HidePopup()
    {
        base.HidePopup();
    }
    public override void Next()
    {
        if (SoundManager.instance != null) SoundManager.instance.UI_button_Click();
        if (container != null)
        {
            if (container.unit is UnitMode2)
            {
                UnitMode2 mode2 = container.unit as UnitMode2;
                if (FireBaseEventManager.instance != null)
                {
                    FireBaseEventManager.instance.P_Answer_BTT_Next_Level(mode2.indexUnit, mode2.CurIndexScene);
                }
            }
            container.unit.Next();
            gameObject.SetActive(false);
            if (PickupCorrectAns.instance != null) PickupCorrectAns.instance.RUN = false;
        }
    }
    public void NextToExplanation()
    {
        if (SoundManager.instance != null) SoundManager.instance.UI_button_Click();
        container = ButtonStageManager.instance.unitStage;
        if (container != null && container.unit != null)
        {
            if (container.unit is UnitMode2)
            {
                UnitMode2 mode2 = container.unit as UnitMode2;
                if (FireBaseEventManager.instance != null)
                {
                    FireBaseEventManager.instance.P_Win_BTT_Next_Level(mode2.indexUnit, mode2.CurIndexScene);
                }
            }
        }
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
    }
    public void Refresh()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
    }
    public override void Try()
    {
        if (SoundManager.instance != null) SoundManager.instance.UI_button_Click();
        if (container.unit is UnitMode2)
        {
            UnitMode2 mode2 = container.unit as UnitMode2;
            if (FireBaseEventManager.instance != null)
            {
                FireBaseEventManager.instance.P_Answer_BTT_Try_Level(mode2.indexUnit, mode2.CurIndexScene);
            }
        }
        HidePopup();
    }
}
