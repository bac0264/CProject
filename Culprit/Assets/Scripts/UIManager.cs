using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Animator ani;
    private void OnValidate()
    {
        if (ani == null) ani = GetComponent<Animator>();
    }
    public void ClickedStages()
    {
        ani.Play("Hide");
    }
    public void NextScene()
    {
        SceneManager.LoadScene("MenuToStage");
    }
    public void ClickSetting()
    {
        if (PopupContainer.instance != null) PopupContainer.instance.ShowSettingPopup();
    }
}
