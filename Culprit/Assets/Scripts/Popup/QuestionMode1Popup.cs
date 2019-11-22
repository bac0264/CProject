using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuestionMode1Popup : BasePopup
{
    public static QuestionMode1Popup instance;


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
        if (unitStage != null && unitStage.unit != null && unitStage.unit is UnitMode1)
        {
            UnitMode1 unitMode1 = unitStage.unit as UnitMode1;
            question.text = LevelDataManager.instance.GetQuestion(unitMode1.indexStage, unitMode1.indexUnit, 0);
            Debug.Log(question.text);
        }
        base.ShowPopup();
    }
    public override void HidePopup()
    {
        //StartCoroutine(_HidePopup());
        if (SoundManager.instance != null) SoundManager.instance.UI_button_Click();
        base.HidePopup();
    }
    IEnumerator _HidePopup()
    {
        closeBtn.Play("Click");
        yield return new WaitForSeconds(KeySave.TIME_BACK);
        base.HidePopup();
    }
}
