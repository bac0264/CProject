using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    public Text Menu_Gold_Text;
    public Text Daily_Gold_Text;
    private void Awake()
    {
        if (instance == null) instance = this;
        if (!PlayerPrefs.HasKey(KeySave.IS_THE_FIRST_TIME))
        {
            PlayerPrefs.SetInt(KeySave.IS_THE_FIRST_TIME, 0);
        }
        else
        {
            if (DailyManager.instance != null)
                DailyManager.instance.dailyPanel.LoadData();
        }
    }
}
