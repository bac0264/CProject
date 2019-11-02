using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class LevelDataManager : MonoBehaviour
{
    public static LevelDataManager instance;
    public string URL = "http://localhost/connect/ConnectCSV.php";
    public LevelDataContainer levelData;
    public string data;
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
        WWW www = new WWW(URL);
        yield return www;
        if (www.error != null)
        {
            Debug.Log("Error");
        }
        else
        {
            Debug.Log("got the php information");
            data = www.text;
            levelData.LoadLevelData(data);
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
