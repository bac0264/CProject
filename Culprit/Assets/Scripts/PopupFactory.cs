using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PopupFactory : MonoBehaviour
{
    public static PopupFactory instance;
    private Transform container;
    private Dictionary<string, BasePopup> popupDictionaries;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(this);
        }
        SetPopupDictionary();
    }
    private void SetPopupDictionary()
    {
        BasePopup[] listPopup = Resources.LoadAll<BasePopup>("Popup");
        popupDictionaries = new Dictionary<string, BasePopup>();
        foreach (BasePopup _popup in listPopup)
        {
            popupDictionaries.Add(_popup.type.ToString(), _popup);
        }
    }

    public void UpdateContainer()
    {
        if (container == null) container = GameObject.FindGameObjectWithTag(KeySave.CONTAINER_POPUP).transform;
    }

    public void GetPopup(BasePopup.TypeOfPopup type)
    {
        switch (type)
        {
            case BasePopup.TypeOfPopup.PO_Question:
                if (QuestionPopup.instance != null)
                {
                    QuestionPopup.instance.ShowPopup();
                    return;
                }
                break;
            case BasePopup.TypeOfPopup.PO_QuestionMode1:
                if (QuestionMode1Popup.instance != null)
                {
                    QuestionMode1Popup.instance.ShowPopup();
                    return;
                }
                break;
            case BasePopup.TypeOfPopup.PO_Hint:
                if (HintPopup.instance != null)
                {
                    HintPopup.instance.ShowPopup();
                    return;
                }
                break;
            case BasePopup.TypeOfPopup.PO_Lose:
                if (LosePopup.instance != null)
                {
                    LosePopup.instance.ShowPopup();
                    return;
                }
                break;
            case BasePopup.TypeOfPopup.PO_Setting:
                if (SettingPopup.instance != null)
                {
                    SettingPopup.instance.ShowPopup();
                    return;
                }

                break;
            case BasePopup.TypeOfPopup.PO_Win:
                if (WinPopup.instance != null)
                {
                    WinPopup.instance.ShowPopup();
                    return;
                }
                break;
            case BasePopup.TypeOfPopup.PO_Correct:
                if (CorrectPopup.instance != null)
                {
                    CorrectPopup.instance.ShowPopup();
                    return;
                }
                break;
            case BasePopup.TypeOfPopup.PO_Incorrect:
                if (IncorrectPopup.instance != null)
                {
                    IncorrectPopup.instance.ShowPopup();
                    return;
                }
                break;
        }
        InitPopup(type);
    }
    public void InitPopup(BasePopup.TypeOfPopup type)
    {
        UpdateContainer();
        BasePopup popupNeed = popupDictionaries[type.ToString()];
        if (popupNeed == null) return;
        GameObject obj = Instantiate(popupNeed.gameObject, container);
        BasePopup popup = obj.GetComponent<BasePopup>();
        if (popup != null) popup.ShowPopup();
    }
    public void HideAllPopup()
    {
        foreach (BasePopup _element in popupDictionaries.Values)
        {
            _element.HidePopup();
        }
    }
 
}
