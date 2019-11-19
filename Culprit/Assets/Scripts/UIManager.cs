using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Animator ani;
    private void Awake()
    {
        //if(PlayerPrefs.GetInt(KeySave.MENU_UI_OPEN, 0) == 1)
        //{
        //    ani.Play("Open");
        //}
        //else
        //{
        //    PlayerPrefs.SetInt(KeySave.MENU_UI_OPEN, 1);
        //}
    }
    private void OnValidate()
    {
        if (ani == null) ani = GetComponent<Animator>();
    }
    public void ClickedStages()
    {
        if (FireBaseEventManager.instance != null)
        {
            FireBaseEventManager.instance.MENU_Taptoplay();
        }
        if (SoundManager.instance != null) SoundManager.instance.UI_button_Click();
        ani.Play("Hide");
    }
    public void NextScene()
    {
        SceneManager.LoadScene("MenuToStage");
    }
    public void ClickSetting()
    {
        if (FireBaseEventManager.instance != null)
        {
            FireBaseEventManager.instance.MENU_BtnSetting();
        }
        if (PopupFactory.instance != null) PopupFactory.instance.ShowPopup(BasePopup.TypeOfPopup.PO_Setting);
    }
}
