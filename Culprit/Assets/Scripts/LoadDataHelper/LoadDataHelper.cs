using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDataHelper : MonoBehaviour
{

    public TextAsset QuestionData;
    public QuestionDataContainer quesList;

    public TextAsset AnswerData;
    public AnswerDataContainer ansList;
    public void LoadData()
    {
        var dataQues = CSVReader.Read(QuestionData);
        quesList.LoadQuestionData(dataQues);
        var dataAns = CSVReader.Read(AnswerData);
        ansList.LoadQuestionData(dataAns);
    }

}