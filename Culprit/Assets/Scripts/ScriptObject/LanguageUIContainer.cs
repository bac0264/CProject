using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[CreateAssetMenu(fileName = "LanguageData", menuName = "MENU/UILanguage", order = 1)]
public class LanguageUIContainer : ScriptableObject
{
    public List<UIData> dataList;
    public void LoadUIData(List<Dictionary<string, string>> dataCSV)
    {
        dataList = new List<UIData>();
        for (int i = 0; i < dataCSV.Count; i++)
        {
            UIData _data = new UIData(dataCSV[i]);
            dataList.Add(_data);
        }
        Debug.Log(dataList.Count);
    }
    // load sheet drive
    public void LoadUIData(ES3Spreadsheet sheet2)
    {
        dataList = new List<UIData>(); 
        for (int row = 1; row < sheet2.RowCount; row++)
        {
            for (int col = 0; col < sheet2.ColumnCount;)
            {
                UIData _data = new UIData(sheet2, row);
                dataList.Add(_data);
                break;
            }
        }
    }
}
[System.Serializable]
public class UIData
{
    public string NAME;
    public string DATA;
    public UIData(Dictionary<string, string> data)
    {
        try
        {
            NAME = data["NAME"];
            DATA = data["DATA"];
        }
        catch(Exception e)
        {

        }
    }
    public UIData(ES3Spreadsheet sheet2, int row)
    {
        for (int col = 0; col < sheet2.ColumnCount;)
        {
            NAME = sheet2.GetCell<string>(col++, row);
            DATA = sheet2.GetCell<string>(col++, row);
            break;
        }
    }
}
