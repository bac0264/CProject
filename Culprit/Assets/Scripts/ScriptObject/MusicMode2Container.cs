using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "MusicMode2Data", menuName = "MENU/MusicMode2Data", order = 1)]
public class MusicMode2Container : ScriptableObject
{
    public List<MusicMode2> musicDataList;
    public void LoadMusicData(List<Dictionary<string, string>> dataCSV)
    {
        musicDataList = new List<MusicMode2>();
        for (int i = 0; i < dataCSV.Count; i++)
        {
            MusicMode2 _data = new MusicMode2(dataCSV[i]);
            musicDataList.Add(_data);
        }
    }
    public MusicMode2 GetMusicMode2(string Level)
    {
        foreach(MusicMode2 musicMode2 in musicDataList)
        {
            if (musicMode2.Level == Level) return musicMode2;
        }
        return null;
    }
}
[System.Serializable]
public class MusicMode2
{
    public string Level;
    public string SoundCode;
    public MusicMode2(Dictionary<string, string> data)
    {
        Level = data["LEVEL"];
        SoundCode = data["SoundCode"];
    }
}
