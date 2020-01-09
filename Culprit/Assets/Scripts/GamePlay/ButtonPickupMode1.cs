using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;
public class ButtonPickupMode1 : MonoBehaviour
{
    public static ButtonPickupMode1 Instance;
    public List<Button> btns;
    public ObjectPooling objPooling;

    private void OnValidate()
    {
        if (objPooling == null) objPooling = GetComponent<ObjectPooling>();
    }
    private void Start()
    {
        SetupInstance();
    }
    public void SetupInstance()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void AddBtns(UnitStage unitstage)
    {
        if (unitstage.unit != null && unitstage.unit is UnitMode1)
        {
            UnitMode1 unit = unitstage.unit as UnitMode1;
            int amount = unit.btnContainer.childCount;
            if (amount > 0)
            {
                btns.Clear();
                for (int i = 0; i < amount; i++)
                {
                    GameObject obj = objPooling.getObjectPooling();
                    Button btn = obj.GetComponent<Button>();
                    if (btn != null)
                    {
                        btn.onClick.RemoveAllListeners();
                        Vector3 pos = unit.btnContainer.GetChild(i).transform.localPosition;
                        if (unitstage._index == 2)
                        {
                            pos.x -= 1;
                            btn.transform.DOMove(pos, 0);
                        }
                        else if (unitstage._index == 5)
                        {
                            if (i == 0)
                            {
                                pos.x -= 1.2f;
                                btn.transform.DOMove(pos, 0);
                            }
                            if( i == 1)
                            {
                                pos.y += 4.5f;
                                btn.transform.DOMove(pos, 0);
                            }
                        }
                        else
                            btn.transform.DOMove(pos, 0);
                        int result = unit.GetResult(i);
                        btn.onClick.AddListener(delegate { SetupBtn(unitstage, result); });
                        btn.transform.GetChild(0).GetComponent<Text>().text = (i + 1).ToString();
                        btns.Add(btn);
                    }
                }
            }
        }
        UnactiveBtn();
    }
    void SetupBtn(UnitStage unitStage, int result)
    {
        if (unitStage != null && unitStage.unit != null && unitStage.unit is UnitMode1)
        {
            if (QuestionMode1Popup.instance != null) QuestionMode1Popup.instance.HidePopup();
            UnitMode1 unit = unitStage.unit as UnitMode1;
            if (unit.IsWin(result))
            {
            }
        }
        UnactiveBtn();
    }
    public void ActivePickupBtn()
    {
        foreach (Button btn in btns)
        {
            btn.gameObject.SetActive(true);
        }

    }
    public void UnactiveBtn()
    {
        foreach (Button btn in btns)
        {
            Debug.Log("run");
            btn.gameObject.SetActive(false);
        }
    }
}
