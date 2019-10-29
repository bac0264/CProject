using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "AnswerData", menuName = "Stages/AnswerData", order = 1)]
public class AnswerDataContainer : ScriptableObject
{
    public List<AnswerData> answerList;

    public void LoadQuestionData(List<Dictionary<string, string>> dataCSV)
    {
        answerList = new List<AnswerData>();
        for (int i = 0; i < dataCSV.Count; i++)
        {
            AnswerData dataEnemy = new AnswerData(dataCSV[i]);
            answerList.Add(dataEnemy);
        }
    }

}
[System.Serializable]
public class AnswerData
{
    public int MODE;
    public int LEVEL;
    public List<string> listAnswer;
    public AnswerData(Dictionary<string, string> data)
    {
        string ANS_1;
        string ANS_2;
        string ANS_3;
        string ANS_4;
        listAnswer = new List<string>();
        MODE = int.Parse(data["MODE"]);
        LEVEL = int.Parse(data["LEVEL"]);
        ANS_1 = data["ANS_1"];
        listAnswer.Add(ANS_1);
        ANS_2 = data["ANS_2"];
        listAnswer.Add(ANS_2);
        ANS_3 = data["ANS_3"];
        listAnswer.Add(ANS_3);
        ANS_4 = data["ANS_4"];
        listAnswer.Add(ANS_4);
    }
}
