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

        }
        container = GameObject.FindGameObjectWithTag(KeySave.CONTAINER_POPUP).transform;
    }
    public IncorrectPopup incorrectPopupPrefab;
    public CorrectPopup correctPopupPrefab;
    public LosePopup losePrefab;
    public WinPopup winPrefab;
    public QuestionPopup questionPopup;

    public void GetIncorrectPopup()
    {
        GameObject obj = Instantiate(incorrectPopupPrefab.gameObject, container);
        IncorrectPopup popup = obj.GetComponent<IncorrectPopup>();
        if (popup != null) popup.ShowPopup();
    }
    public void GetCorrectPopupPrefab()
    {
        GameObject obj = Instantiate(correctPopupPrefab.gameObject, container);
        CorrectPopup popup = obj.GetComponent<CorrectPopup>();
        if (popup != null) popup.ShowPopup();
    }
    public void GetWinPopup()
    {
        GameObject obj = Instantiate(winPrefab.gameObject, container);
        WinPopup popup = obj.GetComponent<WinPopup>();
        if (popup != null) popup.ShowPopup();
    }
    public void GetLosePopup()
    {
        GameObject obj = Instantiate(losePrefab.gameObject, container);
        LosePopup popup = obj.GetComponent<LosePopup>();
        if (popup != null) popup.ShowPopup();
    }
    public void GetQuestionPopup()
    {
        GameObject obj = Instantiate(questionPopup.gameObject, container);
        QuestionPopup popup = obj.GetComponent<QuestionPopup>();
        if (popup != null) popup.ShowPopup();
    }

    //---------------------------------------
    public void ShowQuestionPopup()
    {
        if (QuestionPopup.instance == null) GetQuestionPopup();
        else
            QuestionPopup.instance.ShowPopup();

    }
    public void ShowCorrectPopup()
    {
        if (CorrectPopup.instance == null) GetCorrectPopupPrefab();
        else
            CorrectPopup.instance.ShowPopup();

    }
    public void ShowIncorrectPopup()
    {
        if (IncorrectPopup.instance == null) GetIncorrectPopup();
        else
            IncorrectPopup.instance.ShowPopup();

    }
    public void ShowWinPopup()
    {
        if (WinPopup.instance == null) GetWinPopup();
        else
            WinPopup.instance.ShowPopup();

    }
    public void ShowLosePopup()
    {
        if (LosePopup.instance == null) GetLosePopup();
        else
            LosePopup.instance.ShowPopup();
    }
}
