using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SaveLoadData
{
    // ---------------------------- Stage Save Load
    public static void SaveDataStage(int indexStage, int indexUnitStage)
    {
        PlayerPrefs.SetInt(GetKeyStage(indexStage), indexUnitStage);
    }
    public static int LoadDataStage(int indexStage)
    {
        return PlayerPrefs.GetInt(GetKeyStage(indexStage));
    }
    public static string GetKeyStage(int indexStage)
    {
        return (KeySave.STAGE_DATA + indexStage.ToString());
    }
    //------------------------------ UnitStage Save Load

    public static void SaveDataUnitStage(int indexStage, int indexUnitStage, int MaxIndexScene, bool IsWin)
    {
        PlayerPrefs.SetString(GetKeyUnitStage(indexStage, indexUnitStage), MaxIndexScene.ToString() + "-" + IsWin.ToString());
    }
    public static void LoadDataUnitStage(int indexStage, int indexUnitStage, ref int MaxIndexScene, ref bool IsWin)
    {
        string temp = PlayerPrefs.GetString(GetKeyUnitStage(indexStage, indexUnitStage));
        string[] datas = temp.Split('-');
        if (datas.Length >= 2)
        {
            if (int.TryParse(datas[0], out MaxIndexScene)) { }
            else MaxIndexScene = 0; ;
            if (bool.TryParse(datas[1], out IsWin)){ }
            else IsWin = false;
        }
    }
    public static string GetKeyUnitStage(int indexStage, int indexUnitStage)
    {
        Debug.Log(GetKeyStage(indexStage) + "_" + indexUnitStage.ToString());
        return (GetKeyStage(indexStage) + "_" + indexUnitStage.ToString());
    }

}
