using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDataHelper : MonoBehaviour
{

    public TextAsset LevelDataCSV;
    public LevelDataContainer levelData;
    public void LoadData()
    {
        var dataQues = CSVReader.Read(LevelDataCSV);
        levelData.LoadLevelData(dataQues);
    }

}