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
    public IncorrectPopup incorrectPopupPrefab;
    public CorrectPopup correctPopupPrefab;
    public LosePopup losePrefab;
    public WinPopup winPrefab;
    public QuestionPopup questionPopupPrefab;
    public SettingPopup settingPopupPrefab;
    public void UpdateContainer()
    {
        if(container == null) container = GameObject.FindGameObjectWithTag(KeySave.CONTAINER_POPUP).transform; 
    }
    public void GetPopup(BasePopup prefab)
    {
        UpdateContainer();
        GameObject obj = Instantiate(prefab.gameObject, container);
        BasePopup popup = obj.GetComponent<BasePopup>();
        if (popup != null) popup.ShowPopup();
    }
    //---------------------------------------
    public void ShowQuestionPopup()
    {
        if (QuestionPopup.instance == null) GetPopup(questionPopupPrefab);
        else
            QuestionPopup.instance.ShowPopup();

    }
    public void ShowCorrectPopup()
    {
        if (CorrectPopup.instance == null) GetPopup(correctPopupPrefab);
        else
            CorrectPopup.instance.ShowPopup();

    }
    public void ShowIncorrectPopup()
    {
        if (IncorrectPopup.instance == null) GetPopup(incorrectPopupPrefab);
        else
            IncorrectPopup.instance.ShowPopup();

    }
    public void ShowWinPopup()
    {
        if (WinPopup.instance == null) GetPopup(winPrefab);
        else
            WinPopup.instance.ShowPopup();

    }
    public void ShowLosePopup()
    {
        if (LosePopup.instance == null) GetPopup(losePrefab);
        else
            LosePopup.instance.ShowPopup();
    }
    public void ShowSettingPopup()
    {
        if (SettingPopup.instance == null) GetPopup(settingPopupPrefab);
        else
            SettingPopup.instance.ShowPopup();
    }
}
