using UnityEngine;
using System.Collections;

public class PopupContainer : MonoBehaviour
{
    public static PopupContainer instance;
    public Transform container;
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
    public BasePopup[] listPopup;

    private void OnValidate()
    {
        if (listPopup.Length == 0) listPopup = Resources.LoadAll<BasePopup>("Popup");
    }
    public void UpdateContainer()
    {
        if(container == null) container = GameObject.FindGameObjectWithTag(KeySave.CONTAINER_POPUP).transform; 
    }
    
    public void GetPopup(BasePopup.TypeOfPopup type)
    {
        UpdateContainer();
        BasePopup popupNeed = null;
        foreach (BasePopup _popup in listPopup)
        {
            if (_popup.type.ToString().Equals(type.ToString()))
            {
                popupNeed = _popup;
                break;
            }
        }
        if (popupNeed == null) return;
        GameObject obj = Instantiate(popupNeed.gameObject, container);
        BasePopup popup = obj.GetComponent<BasePopup>();
        if (popup != null) popup.ShowPopup();
    }
    //---------------------------------------
    public void ShowQuestionPopup()
    {
        if (QuestionPopup.instance == null) GetPopup(BasePopup.TypeOfPopup.Question);
        else
            QuestionPopup.instance.ShowPopup();

    }
    public void ShowQuestionPopupMode1()
    {
        if (QuestionPopup.instance == null) GetPopup(BasePopup.TypeOfPopup.QuestionMode1);
        else
            QuestionPopup.instance.ShowPopup();

    }
    public void ShowCorrectPopup()
    {
        if (CorrectPopup.instance == null) GetPopup(BasePopup.TypeOfPopup.Correct);
        else
            CorrectPopup.instance.ShowPopup();

    }
    public void ShowIncorrectPopup()
    {
        if (IncorrectPopup.instance == null) GetPopup(BasePopup.TypeOfPopup.Incorrect);
        else
            IncorrectPopup.instance.ShowPopup();

    }
    public void ShowWinPopup()
    {
        if (WinPopup.instance == null) GetPopup(BasePopup.TypeOfPopup.Win);
        else
            WinPopup.instance.ShowPopup();

    }
    public void ShowLosePopup()
    {
        if (LosePopup.instance == null) GetPopup(BasePopup.TypeOfPopup.Lose);
        else
            LosePopup.instance.ShowPopup();
    }
    public void ShowSettingPopup()
    {
        if (SettingPopup.instance == null) GetPopup(BasePopup.TypeOfPopup.Setting);
        else
            SettingPopup.instance.ShowPopup();
    }
    public void ShowHintPopup()
    {
        if (HintPopup.instance == null) GetPopup(BasePopup.TypeOfPopup.Hint);
        else
            HintPopup.instance.ShowPopup();
    }
}
