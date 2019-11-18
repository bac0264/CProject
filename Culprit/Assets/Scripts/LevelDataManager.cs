using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

public class LevelDataManager : MonoBehaviour
{
    public static LevelDataManager instance;
    private Dictionary<string, string> dictionaryUI;

    public ConnectServerManager connect;
    public TextScript[] textScripts;
    public TextmeshScript[] textmeshScripts;
    public LevelDataContainer levelData;
    public LanguageUIContainer languageUIContainer;


    private void OnValidate()
    {
        if (connect == null) connect = FindObjectOfType<ConnectServerManager>();
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else { Destroy(this); }
        if (PlayerPrefs.GetInt(KeySave.LANGUAGE_IS_THE_FIRST_TIME, 0) == 0)
        {
            connect.SetupForTheFirst();
        }
        else
            GetDataFromServer();
    }
    public void GetDataFromServer()
    {
        connect.GetDataFromServer();
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

    public string GetStringFromDictionaryUI(string key)
    {
        if (dictionaryUI == null) return " ";
        return dictionaryUI[key];
    }
    public void SetDictionaryUI()
    {
        dictionaryUI = new Dictionary<string, string>();
        foreach (UIData data in languageUIContainer.dataList)
        {
            dictionaryUI.Add(data.NAME, data.DATA);
        }
    }
    public void UpdateAllTextUI()
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
