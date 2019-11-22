using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuestionPopup : BasePopup
{
    public static QuestionPopup instance;


    public Text question;

    public UnitStage unitStage;
    public Animator closeBtn;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public override void ShowPopup()
    {
        unitStage = ButtonStageManager.instance.unitStage;

        if (unitStage != null && unitStage.unit != null && unitStage.unit is UnitMode2)
        {
            UnitMode2 unitMode2 = unitStage.unit as UnitMode2;
            question.text = LevelDataManager.instance.GetQuestion(unitMode2.indexStage, unitMode2.indexUnit, unitMode2.CurIndexScene);
        }
        base.ShowPopup();
    }
    public override void HidePopup()
    {
        if (SoundManager.instance != null) SoundManager.instance.UI_button_Click();
        //StartCoroutine(_HidePopup());
        if (PickupCorrectAns.instance != null && PickupCorrectAns.instance.gameObject.activeInHierarchy) PickupCorrectAns.instance.Show_Tutorial();
        base.HidePopup();
    }
    IEnumerator _HidePopup()
    {
        closeBtn.Play("Click");
        yield return new WaitForSeconds(KeySave.TIME_BACK);
        base.HidePopup();
    }
}
