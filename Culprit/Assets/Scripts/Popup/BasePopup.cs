using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BasePopup : MonoBehaviour
{
    public enum TypeOfPopup
    {
        Correct,
        Incorrect,
        Win,
        Lose,
        Question,
        Hint,
        QuestionMode1,
        Setting
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
        SceneManager.LoadScene("Menu");
    }
}
