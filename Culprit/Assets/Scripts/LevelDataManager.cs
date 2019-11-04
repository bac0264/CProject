using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class LevelDataManager : MonoBehaviour
{
    public static LevelDataManager instance;
    private const string URL = "https://docs.google.com/spreadsheets/d/e/2PACX-1vSlGpenyyFcYaFa_zFoY_EXXJstyDiaf12TH_srIw6nlhcDjpVEWFiJUIWYoqVh7KeEme7IAqMT-Fj9/pub?gid=0&single=true&output=csv";
    public LevelDataContainer levelData;
    public TextAsset backup;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else { Destroy(this); }
        GetDataFromServer();
    }
    public void GetDataFromServer()
    {
        StartCoroutine(connectServer());
    }
    IEnumerator connectServer()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();
        if (www.error != null)
        {
            Debug.Log("Error");
            var dataQues = CSVReader.Read(backup);
            levelData.LoadLevelData(dataQues);
        }
        else
        {
            
            Debug.Log("got the php information");
            //  levelData.LoadLevelData(data);
            ReadFileCSV.SaveGoogleSheetData("Level", www.downloadHandler.text);
            ES3Spreadsheet sheet = ReadFileCSV.ReadFileCsv("Level");
            ReadFileCSV.HandleDataCSV(sheet);
            levelData.LoadLevelData(sheet);
        }

    }
    public string GetAnswer(int Stage, int UnitStage, int indexScene)
    {
        for (int i = 0; i < levelData.levelList.Count; i++)
        {
            if (levelData.levelList[i].MODE == (Stage + 1) && levelData.levelList[i].LEVEL == (UnitStage + 1))
            {
                return levelData.levelList[i].listAnswer[indexScene];
            }
        }
        return " ";
    }
    public string GetQuestion(int Stage, int UnitStage, int indexScene)
    {
        for (int i = 0; i < levelData.levelList.Count; i++)
        {
            if (levelData.levelList[i].MODE == (Stage + 1) && levelData.levelList[i].LEVEL == (UnitStage + 1))
            {
                return levelData.levelList[i].listQues[indexScene];
            }
        }
        return " ";
    }
    public string GetHint(int Stage, int UnitStage, int indexScene)
    {
        for (int i = 0; i < levelData.levelList.Count; i++)
        {
            if (levelData.levelList[i].MODE == (Stage + 1) && levelData.levelList[i].LEVEL == (UnitStage + 1))
            {
                return levelData.levelList[i].listHint[indexScene];
            }
        }
        return " ";
    }
}
