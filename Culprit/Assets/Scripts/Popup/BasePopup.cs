using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BasePopup : MonoBehaviour
{
    public enum TypeOfPopup
    {
        PO_Correct,
        PO_Incorrect,
        PO_Win,
        PO_Lose,
        PO_Question,
        PO_Hint,
        PO_QuestionMode1,
        PO_Setting,
        PO_LevelCMS
    }
    public TypeOfPopup type;
    public virtual void ShowPopup()
    {
        gameObject.SetActive(true);
    }
    public virtual void HidePopup()
    {
        gameObject.SetActive(false);
    }
    public virtual void Next()
    {
        HidePopup();
    }
    public virtual void Try()
    {
        HidePopup();
    }
    public virtual void Home()
    {
        if (StageManager.instance != null) StageManager.instance.Home();
        if (ButtonStageManager.instance != null) ButtonStageManager.instance.Home();
    }
}
