using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ConnectServerManager : MonoBehaviour
{
    private const string URL_EnglishLevel = "https://docs.google.com/spreadsheets/d/e/2PACX-1vSlGpenyyFcYaFa_zFoY_EXXJstyDiaf12TH_srIw6nlhcDjpVEWFiJUIWYoqVh7KeEme7IAqMT-Fj9/pub?output=csv";
    private const string URL_VietnameseLevel = "https://docs.google.com/spreadsheets/d/e/2PACX-1vTRt8Eh3_kGRY5FJ--Z5w3eX534xEnI0yPyg55WDtSmLi89ADRMDgXt89dYWiEjyEIMoMkMSOJw3yBJ/pub?output=csv";
    private const string URL_VietnameseUI = "https://docs.google.com/spreadsheets/d/e/2PACX-1vTxgAhB3kCr3KiR8l_PLReZNiJzSbeSJPpHmkYy7gY5JrO344KrLmGDXroW_CBQ-HnQk7alz3_K96BV/pub?output=csv";
    private const string URL_EnglishUI = "https://docs.google.com/spreadsheets/d/e/2PACX-1vTcfHmf3jbCT7gk-C7OOtM70KxGPQ_XnMnCxU5TDHiba0rfnmTYycLZHjgmDIWFzdeCZ8g8q9t0pVXt/pub?output=csv";

    public TextAsset backupLevelEnglish;
    public TextAsset backupLevelVietnamese;

    public TextAsset backupUIEnglish;
    public TextAsset backupUIVietnamese;

    public void GetDataFromServer()
    {
        StartCoroutine(LevelLanguageConnectServer());
        StartCoroutine(UILanguageConnectServer());
    }
    public void SetupForTheFirst()
    {
        var dataQues = CSVReader.Read(backupLevelEnglish);
        var dataQues_2 = CSVReader.Read(backupUIEnglish);
        Debug.Log("run");
        PlayerPrefs.SetInt(KeySave.LANGUAGE, 1);
        if (Application.systemLanguage == SystemLanguage.Vietnamese)
        {
            dataQues = CSVReader.Read(backupLevelVietnamese);
            dataQues_2 = CSVReader.Read(backupUIVietnamese);
            PlayerPrefs.SetInt(KeySave.LANGUAGE, 0);
        }
        else if(Application.systemLanguage == SystemLanguage.English)
        {
            dataQues = CSVReader.Read(backupLevelEnglish);
            dataQues_2 = CSVReader.Read(backupUIEnglish);
            PlayerPrefs.SetInt(KeySave.LANGUAGE, 1);
        }
        else
        {

        }
        LevelDataManager.instance.levelData.LoadLevelData(dataQues);
        LevelDataManager.instance.languageUIContainer.LoadUIData(dataQues_2);
        LevelDataManager.instance.SetDictionaryUI();
        LevelDataManager.instance.UpdateAllTextUI();
    }
    IEnumerator LevelLanguageConnectServer()
    {
        UnityWebRequest www = null;
        // 0 is Vietnamese, 1 is English and else ...
        if (PlayerPrefs.GetInt(KeySave.LANGUAGE, 1) == 1)
        {
            www = UnityWebRequest.Get(URL_EnglishLevel);
        }
        else if (PlayerPrefs.GetInt(KeySave.LANGUAGE, 1) == 0)
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
            var dataQues = CSVReader.Read(backupLevelEnglish);
            if (PlayerPrefs.GetInt(KeySave.LANGUAGE, 1) == 1)
            {
                dataQues = CSVReader.Read(backupLevelEnglish);
            }
            else if (PlayerPrefs.GetInt(KeySave.LANGUAGE, 1) == 0)
            {
                dataQues = CSVReader.Read(backupLevelVietnamese);
            }
            LevelDataManager.instance.levelData.LoadLevelData(dataQues);
        }
        else
        {
            //  levelData.LoadLevelData(data);
            ReadFileCSV.SaveGoogleSheetData("Level", www.downloadHandler.text);
            ES3Spreadsheet sheet = ReadFileCSV.ReadFileCsv("Level");
            ReadFileCSV.HandleDataCSV(sheet);
            LevelDataManager.instance.levelData.LoadLevelData(sheet);
        }

    }
    IEnumerator UILanguageConnectServer()
    {
        LevelDataManager data = LevelDataManager.instance;
        if (data != null)
        {
            UnityWebRequest www = null;
            // 0 is Vietnamese, 1 is English and else ...
            if (PlayerPrefs.GetInt(KeySave.LANGUAGE, 1) == 1)
            {
                www = UnityWebRequest.Get(URL_EnglishUI);
            }
            else if (PlayerPrefs.GetInt(KeySave.LANGUAGE, 1) == 0)
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
                var dataQues = CSVReader.Read(backupUIEnglish);
                if (PlayerPrefs.GetInt(KeySave.LANGUAGE, 1) == 1)
                {
                    dataQues = CSVReader.Read(backupUIEnglish);
                }
                else if (PlayerPrefs.GetInt(KeySave.LANGUAGE, 1) == 0)
                {
                    dataQues = CSVReader.Read(backupUIVietnamese);
                }
                LevelDataManager.instance.languageUIContainer.LoadUIData(dataQues);
                LevelDataManager.instance.SetDictionaryUI();
                LevelDataManager.instance.UpdateAllTextUI();
            }
            else
            {
                ReadFileCSV.SaveGoogleSheetData("UILanguage", www.downloadHandler.text);
                ES3Spreadsheet sheet = ReadFileCSV.ReadFileCsv("UILanguage");
                ReadFileCSV.HandleDataCSV(sheet);
                LevelDataManager.instance.languageUIContainer.LoadUIData(sheet);
                LevelDataManager.instance.SetDictionaryUI();
                LevelDataManager.instance.UpdateAllTextUI();
            }
        }
        else yield return null;
    }
}
