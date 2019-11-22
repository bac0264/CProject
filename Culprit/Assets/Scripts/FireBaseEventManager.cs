using Firebase.Analytics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBaseEventManager : MonoBehaviour
{
    public static FireBaseEventManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void GP_Play_Level(int Level, int Scene)
    {
        Debug.Log("Challenge_Play_LV_" + (Level + 1) + "." + (Scene + 1));
        FirebaseAnalytics.LogEvent("Challenge_Play_LV_" + (Level + 1) + "." + (Scene + 1));
    }
    public void GP_Win_Level(int Level, int Scene)
    {
        Debug.Log("Challenge_Win_LV_" + (Level + 1) + "." + (Scene + 1));
        FirebaseAnalytics.LogEvent("Challenge_Win_LV_" + (Level + 1) + "." + (Scene + 1));
    }
    public void GP_Lose_Level(int Level, int Scene)
    {
        Debug.Log("Challenge_Lose_LV_" + (Level + 1) + "." + (Scene + 1));
        FirebaseAnalytics.LogEvent("Challenge_Lose_LV_" + (Level + 1) + "." + (Scene + 1));
    }
    public void P_Hint_Level(int Level, int Scene)
    {
        Debug.Log("BTT_Hint_LV_" + (Level + 1) + "." + (Scene + 1));
        FirebaseAnalytics.LogEvent("BTT_Hint_LV_" + (Level + 1) + "." + (Scene + 1));
    }
    public void P_Win_BTT_Next_Level(int Level, int Scene)
    {
        Debug.Log("P_Win_BTT_Next_LV_" + (Level + 1) + "." + (Scene + 1));
        FirebaseAnalytics.LogEvent("P_Win_BTT_Next_LV_" + (Level + 1) + "." + (Scene + 1));
    }
    public void P_Win_BTT_Next_Level(int Level)
    {
        Debug.Log("P_Win_BTT_Next_LV_" + (Level + 1));
        FirebaseAnalytics.LogEvent("P_Win_BTT_Next_LV_" + (Level + 1));
    }
    public void P_Answer_BTT_Next_Level(int Level, int Scene)
    {
        Debug.Log("P_Answer_BTT_Next_LV_" + (Level + 1) + "." + (Scene + 1));
        FirebaseAnalytics.LogEvent("P_Answer_BTT_Next_LV_" + (Level + 1) + "." + (Scene + 1));
    }
    public void P_Answer_BTT_Try_Level(int Level, int Scene)
    {
        Debug.Log("P_Answer_BTT_Try_LV_" + (Level + 1) + "." + (Scene + 1));
        FirebaseAnalytics.LogEvent("P_Answer_BTT_Try_LV_" + (Level + 1) + "." + (Scene + 1));
    }
    public void MENU_Taptoplay()
    {
        Debug.Log("Main_btt_TaptoPlay");
        FirebaseAnalytics.LogEvent("Main_btt_TaptoPlay");
    }
    public void MENU_BtnSetting()
    {
        Debug.Log("Main_btt_setting");
        FirebaseAnalytics.LogEvent("Main_btt_setting");
    }
    public void MENU_OffMuic()
    {
        Debug.Log("P_Setting_btt_offMusic");
        FirebaseAnalytics.LogEvent("P_Setting_btt_offMusic");
    }
    public void MENU_OffSound()
    {
        Debug.Log("P_Setting_btt_offSound");
        FirebaseAnalytics.LogEvent("P_Setting_btt_offSound");
    }
    public void MENU_Language()
    {
        Debug.Log("P_Setting_btt_language");
        FirebaseAnalytics.LogEvent("P_Setting_btt_language");
    }
    public void NAME_MODE(string nameMode)
    {
        Debug.Log("Mode_btt_" + nameMode);
        FirebaseAnalytics.LogEvent("Mode_btt_" + nameMode);
    }
    public void LEVEL_SELECT(int level)
    {
        Debug.Log("Level_btt_" + (level + 1));
        FirebaseAnalytics.LogEvent("Level_btt_" + (level + 1));
    }
}
