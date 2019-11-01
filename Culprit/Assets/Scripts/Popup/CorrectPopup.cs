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
    public override void ShowPopup()
    {
        Refresh();
        container = ButtonStageManager.instance.unitStage;
        if (container != null && container.unit != null && container.unit is UnitMode2)
        {
            UnitMode2 unitMode2 = container.unit as UnitMode2;
            Explanation.text = LevelDataManager.instance.GetQuestion(unitMode2.indexStage, unitMode2.indexUnit, unitMode2.CurIndexScene);
            spriteEvidence.sprite = spriteData.GetSprite(unitMode2.indexUnit, unitMode2.CurIndexScene);
        }
        base.ShowPopup();
    }
    public override void HidePopup()
    {
        base.HidePopup();
    }
    public override void Next()
    {
        if (container != null)
        {
            container.unit.Next();
            gameObject.SetActive(false);
        }
    }
    public void NextToExplanation()
    {
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
        HidePopup();
    }
}
