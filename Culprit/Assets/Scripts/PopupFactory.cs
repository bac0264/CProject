using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PopupFactory : MonoBehaviour
{
    public static PopupFactory instance;
    private Transform container;

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
    }
    

    public void UpdateContainer()
    {
        if (container == null) container = GameObject.FindGameObjectWithTag(KeySave.CONTAINER_POPUP).transform;
    }

    public void ShowPopup(BasePopup.TypeOfPopup type)
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
            case BasePopup.TypeOfPopup.PO_LevelCMS:
                if (LVComingSoonPopup.instance != null)
                {
                    LVComingSoonPopup.instance.ShowPopup();
                    return;
                }
                break;
        }
        InitPopup(type);
    }
    public BasePopup GetPopup(BasePopup.TypeOfPopup type)
    {
        switch (type)
        {
            case BasePopup.TypeOfPopup.PO_Question:
                if (QuestionPopup.instance != null)
                {
                    return QuestionPopup.instance;
                }
                break;
            case BasePopup.TypeOfPopup.PO_QuestionMode1:
                if (QuestionMode1Popup.instance != null)
                {
                    return QuestionMode1Popup.instance;
                }
                break;
            case BasePopup.TypeOfPopup.PO_Hint:
                if (HintPopup.instance != null)
                {
                    return HintPopup.instance;
                }
                break;
            case BasePopup.TypeOfPopup.PO_Lose:
                if (LosePopup.instance != null)
                {
                    return LosePopup.instance;
                }
                break;
            case BasePopup.TypeOfPopup.PO_Setting:
                if (SettingPopup.instance != null)
                {
                    return SettingPopup.instance;
                }

                break;
            case BasePopup.TypeOfPopup.PO_Win:
                if (WinPopup.instance != null)
                {
                    return WinPopup.instance;
                }
                break;
            case BasePopup.TypeOfPopup.PO_Correct:
                if (CorrectPopup.instance != null)
                {
                    return CorrectPopup.instance;
                }
                break;
            case BasePopup.TypeOfPopup.PO_Incorrect:
                if (IncorrectPopup.instance != null)
                {
                    return IncorrectPopup.instance;
                }
                break;
            case BasePopup.TypeOfPopup.PO_LevelCMS:
                if (LVComingSoonPopup.instance != null)
                {
                    return LVComingSoonPopup.instance;
                }
                break;
        }
        return null;
    }
    public void InitPopup(BasePopup.TypeOfPopup type)
    {
        UpdateContainer();
        string link = "Popup/" + type.ToString();
        BasePopup popupNeed = Resources.Load<BasePopup>(link);
        if (popupNeed == null) return;
        GameObject obj = Instantiate(popupNeed.gameObject, container);
        BasePopup popup = obj.GetComponent<BasePopup>();
        if (popup != null) popup.ShowPopup();
    }
    public void HideAllPopup()
    {
        int count = Enum.GetValues(typeof(BasePopup.TypeOfPopup)).Length;
        for (int i = 0; i < count; i++)
        {
            BasePopup.TypeOfPopup type = (BasePopup.TypeOfPopup)i;
            BasePopup _popup = GetPopup(type);
            if (_popup != null) _popup.HidePopup();
        }
    }

}
