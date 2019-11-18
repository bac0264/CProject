using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDataHelper : MonoBehaviour
{

    public TextAsset LevelDataCSV;
    public LevelDataContainer levelData;

    public TextAsset UIDataCSV;
    public LanguageUIContainer languageUIData;

    public TextAsset MusicCSV;
    public MusicMode2Container musicData;
    public void LoadData()
    {
        var dataLevel = CSVReader.Read(LevelDataCSV);
        levelData.LoadLevelData(dataLevel);
        var dataUI = CSVReader.Read(UIDataCSV);
        languageUIData.LoadUIData(dataUI);
        var DataMusic = CSVReader.Read(MusicCSV);
        musicData.LoadMusicData(DataMusic);

    }

}