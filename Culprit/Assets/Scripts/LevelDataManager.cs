using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

public class LevelDataManager : MonoBehaviour
{
    public static LevelDataManager instance;
    private Dictionary<string, string> dictionary;
    private const string URL_EnglishLevel = "https://docs.google.com/spreadsheets/d/e/2PACX-1vSlGpenyyFcYaFa_zFoY_EXXJstyDiaf12TH_srIw6nlhcDjpVEWFiJUIWYoqVh7KeEme7IAqMT-Fj9/pub?output=csv";
    private const string URL_VietnameseLevel = "https://docs.google.com/spreadsheets/d/e/2PACX-1vTRt8Eh3_kGRY5FJ--Z5w3eX534xEnI0yPyg55WDtSmLi89ADRMDgXt89dYWiEjyEIMoMkMSOJw3yBJ/pub?output=csv";
    private const string URL_VietnameseUI = "https://docs.google.com/spreadsheets/d/e/2PACX-1vTxgAhB3kCr3KiR8l_PLReZNiJzSbeSJPpHmkYy7gY5JrO344KrLmGDXroW_CBQ-HnQk7alz3_K96BV/pub?output=csv";
    private const string URL_EnglishUI = "https://docs.google.com/spreadsheets/d/e/2PACX-1vTcfHmf3jbCT7gk-C7OOtM70KxGPQ_XnMnCxU5TDHiba0rfnmTYycLZHjgmDIWFzdeCZ8g8q9t0pVXt/pub?output=csv";

    public TextScript[] textScripts;
    public TextmeshScript[] textmeshScripts;
    public LevelDataContainer levelData;
    public LanguageUIContainer languageUIContainer;
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
        UpdateAllText();
    }
    public void GetDataFromServer()
    {
        StartCoroutine(LevelLanguageConnectServer());
        StartCoroutine(UILanguageConnectServer());
    }
    IEnumerator LevelLanguageConnectServer()
    {
        UnityWebRequest www = null;
        // 0 is Vietnamese, 1 is English and else ...
        if (PlayerPrefs.GetInt(KeySave.LANGUAGE, 0) == 1)
        {
            www = UnityWebRequest.Get(URL_EnglishLevel);
        }
        else if (PlayerPrefs.GetInt(KeySave.LANGUAGE, 0) == 0)
        {
            www = UnityWebRequest.Get(URL_VietnameseLevel);
        }
        else
        {

        }
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

    IEnumerator UILanguageConnectServer()
    {
        UnityWebRequest www = null;
        // 0 is Vietnamese, 1 is English and else ...
        if (PlayerPrefs.GetInt(KeySave.LANGUAGE, 0) == 1)
        {
            www = UnityWebRequest.Get(URL_EnglishUI);
        }
        else if (PlayerPrefs.GetInt(KeySave.LANGUAGE, 0) == 0)
        {
            www = UnityWebRequest.Get(URL_VietnameseUI);
        }
        else
        {

        }
        yield return www.SendWebRequest();
        if (www.error != null)
        {
            Debug.Log("Error");
            //var dataQues = CSVReader.Read(backup);
            //levelData.LoadLevelData(dataQues);
        }
        else
        {
            Debug.Log("got the php information");
            //  levelData.LoadLevelData(data);
            ReadFileCSV.SaveGoogleSheetData("UILanguage", www.downloadHandler.text);
            ES3Spreadsheet sheet = ReadFileCSV.ReadFileCsv("UILanguage");
            ReadFileCSV.HandleDataCSV(sheet);
            languageUIContainer.LoadUIData(sheet);
            SetDictionary();
            UpdateAllText();
        }
    }
    public string GetStringFromDictionary(string key)
    {
        if (dictionary == null) return null;
        return dictionary[key];
    }
    public void SetDictionary()
    {
        dictionary = new Dictionary<string, string>();
        foreach(UIData data in languageUIContainer.dataList)
        {
            dictionary.Add(data.NAME, data.DATA);
        }
        Debug.Log(dictionary["Menu_Title"]);
    }
    public void UpdateAllText()
    {
        textScripts = FindObjectsOfType<TextScript>();
        textmeshScripts = FindObjectsOfType<TextmeshScript>();
        for (int i = 0; i < textScripts.Length; i++)
        {
            textScripts[i].UpdateText();
        }
        for (int i = 0; i < textmeshScripts.Length; i++)
        {
            textmeshScripts[i].UpdateText();
        }
    }
}
