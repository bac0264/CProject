using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "LevelData", menuName = "Stages/LevelData", order = 1)]
public class LevelDataContainer : ScriptableObject
{
    public List<LevelData> levelList;

    public void LoadLevelData(List<Dictionary<string, string>> dataCSV)
    {
        levelList = new List<LevelData>();
        for (int i = 0; i < dataCSV.Count; i++)
        {
            LevelData _data = new LevelData(dataCSV[i]);
            levelList.Add(_data);
        }
    }
    // load php
    public void LoadLevelData(string data)
    {

        levelList = new List<LevelData>();
        string[] datas = data.Split('|');
        for (int i = 0; i < datas.Length; i++)
        {
            string[] unitDatas = datas[i].Split(',');
            LevelData _data = new LevelData(unitDatas);
            levelList.Add(_data);
        }
    }
    // load sheet drive
    public void LoadLevelData(ES3Spreadsheet sheet2)
    {
        levelList = new List<LevelData>();
        for (int row = 1; row < sheet2.RowCount; row++)
        {
            for (int col = 0; col < sheet2.ColumnCount; )
            {
                LevelData _data = new LevelData(sheet2,row);
                levelList.Add(_data);
                break;
            }
        }
    }
}
[System.Serializable]
public class LevelData
{
    public int MODE;
    public int LEVEL;
    public List<string> listAnswer;
    public List<string> listQues;
    public List<string> listHint;
    public LevelData(Dictionary<string, string> data)
    {

        listQues = new List<string>();
        listAnswer = new List<string>();
        listHint = new List<string>();
        MODE = int.Parse(data["MODE"]);
        LEVEL = int.Parse(data["LEVEL"]);
        listQues.Add(data["QUES_1"]);
        listQues.Add(data["QUES_2"]);
        listQues.Add(data["QUES_3"]);
        listQues.Add(data["QUES_4"]);
        listAnswer.Add(data["ANS_1"]);
        listAnswer.Add(data["ANS_2"]);
        listAnswer.Add(data["ANS_3"]);
        listAnswer.Add(data["ANS_4"]);
        listHint.Add(data["HINT_1"]);
        listHint.Add(data["HINT_2"]);
        listHint.Add(data["HINT_3"]);
        listHint.Add(data["HINT_4"]);
    }
    public LevelData(string[] unitDatas)
    {
        listQues = new List<string>();
        listAnswer = new List<string>();
        listHint = new List<string>();
        for (int j = 0; j < unitDatas.Length; j++)
        {
            if (j < unitDatas.Length)
                int.TryParse(unitDatas[j++], out MODE);
            if (j < unitDatas.Length)
                int.TryParse(unitDatas[j++], out LEVEL);
            if (j < unitDatas.Length)
                listQues.Add(unitDatas[j++]);
            if (j < unitDatas.Length)
                listQues.Add(unitDatas[j++]);
            if (j < unitDatas.Length)
                listQues.Add(unitDatas[j++]);
            if (j < unitDatas.Length)
                listQues.Add(unitDatas[j++]);
            if (j < unitDatas.Length)
                listAnswer.Add(unitDatas[j++]);
            if (j < unitDatas.Length)
                listAnswer.Add(unitDatas[j++]);
            if (j < unitDatas.Length)
                listAnswer.Add(unitDatas[j++]);
            if (j < unitDatas.Length)
                listAnswer.Add(unitDatas[j++]);
            if (j < unitDatas.Length)
                listHint.Add(unitDatas[j++]);
            if (j < unitDatas.Length)
                listHint.Add(unitDatas[j++]);
            if (j < unitDatas.Length)
                listHint.Add(unitDatas[j++]);
            if (j < unitDatas.Length)
                listHint.Add(unitDatas[j++]);
            if (j < unitDatas.Length)
                listHint.Add(unitDatas[j++]);
            break;
        }
    }
    public LevelData(ES3Spreadsheet sheet2, int row)
    {
        listQues = new List<string>();
        listAnswer = new List<string>();
        listHint = new List<string>();
        for (int col = 0; col < sheet2.ColumnCount;)
        {
            int.TryParse(sheet2.GetCell<string>(col++, row), out MODE);
            int.TryParse(sheet2.GetCell<string>(col++, row), out LEVEL);

            listQues.Add(sheet2.GetCell<string>(col++, row));
            listQues.Add(sheet2.GetCell<string>(col++, row));
            listQues.Add(sheet2.GetCell<string>(col++, row));
            listQues.Add(sheet2.GetCell<string>(col++, row));

            listAnswer.Add(sheet2.GetCell<string>(col++, row));
            listAnswer.Add(sheet2.GetCell<string>(col++, row));
            listAnswer.Add(sheet2.GetCell<string>(col++, row));
            listAnswer.Add(sheet2.GetCell<string>(col++, row));

            listHint.Add(sheet2.GetCell<string>(col++, row));
            listHint.Add(sheet2.GetCell<string>(col++, row));
            listHint.Add(sheet2.GetCell<string>(col++, row));
            listHint.Add(sheet2.GetCell<string>(col++, row));
            break;
        }
    }
    public LevelData(){}
}
