using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ConnectServerManager : MonoBehaviour
{
    private const string URL_EnglishLevel = "https://docs.google.com/spreadsheets/d/e/2PACX-1vSlGpenyyFcYaFa_zFoY_EXXJstyDiaf12TH_srIw6nlhcDjpVEWFiJUIWYoqVh7KeEme7IAqMT-Fj9/pub?output=csv";
    private const string URL_VietnameseLevel = "https://docs.google.com/spreadsheets/d/e/2PACX-1vTRt8Eh3_kGRY5FJ--Z5w3eX534xEnI0yPyg55WDtSmLi89ADRMDgXt89dYWiEjyEIMoMkMSOJw3yBJ/pub?output=csv";
    private const string URL_VietnameseUI = "https://docs.google.com/spreadsheets/d/e/2PACX-1vTxgAhB3kCr3KiR8l_PLReZNiJzSbeSJPpHmkYy7gY5JrO344KrLmGDXroW_CBQ-HnQk7alz3_K96BV/pub?output=csv";
    private const string URL_EnglishUI = "https://docs.google.com/spreadsheets/d/e/2PACX-1vTcfHmf3jbCT7gk-C7OOtM70KxGPQ_XnMnCxU5TDHiba0rfnmTYycLZHjgmDIWFzdeCZ8g8q9t0pVXt/pub?output=csv";


    public void GetDataFromServer()
    {
        StartCoroutine(LevelLanguageConnectServer());
        StartCoroutine(UILanguageConnectServer());
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
            var dataQues = CSVReader.Read(LevelDataManager.instance.backup);
            LevelDataManager.instance.levelData.LoadLevelData(dataQues);
        }
        else
        {
            Debug.Log("got the php information");
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
                LevelDataManager.instance.languageUIContainer.LoadUIData(sheet);
                LevelDataManager.instance.SetDictionaryUI();
                LevelDataManager.instance.UpdateAllTextUI();
            }
        }
        else yield return null;
    }
}
