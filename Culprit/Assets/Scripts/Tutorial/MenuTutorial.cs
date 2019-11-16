using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class MenuTutorial : MonoBehaviour
{
    public int Order;
    public bool IsDone;
    public virtual void CheckIfHappening()
    {
        if (IsDone)
        {
            MenuTutorialManager.Instance.CompletedTutorial();
        }
    }
    private void Update()
    {
        if (Order == 0 && StageEnhance.instance != null && StageEnhance.instance.isDOMoveTutorialPosition)
        {
            StageEnhance.instance.isDOMoveTutorialPosition = false;
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(0).GetComponent<Image>().DOColor(new Color(1, 1, 1, 1), 2f);
            transform.GetChild(0).GetChild(0).GetComponent<Text>().DOColor(new Color(1, 1, 1, 1), 2f);
            transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>().DOColor(new Color(1, 1, 1, 1), 2f);
        }
        else if (Order == 1 && UnitEnhance.instance != null && UnitEnhance.instance.isDOMoveTutorialPosition)
        {
            UnitEnhance.instance.isDOMoveTutorialPosition = false;
            UnitStage unitStage = StageManager.instance._stageList[0].GetUnitStage(0);
            RectTransform obj = transform.GetChild(0).GetComponent<RectTransform>();
            obj.sizeDelta = unitStage.gameObject.GetComponent<RectTransform>().sizeDelta;
            transform.GetChild(0).DOMove(unitStage.transform.position, 0);
        }
    }
    private void Start()
    {
        if (Order == 0)
            transform.GetChild(0).gameObject.SetActive(false);
    }
}