using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadFileCSV 
{
    public const string subPath = "CsvFile";
    public static ES3Spreadsheet ReadFileCsv(string name)
    {
        Debug.Log(Application.persistentDataPath + subPath + "/" + name + ".csv");
        if (!File.Exists(Application.persistentDataPath + subPath + "/" + name + ".csv"))
        {
            Debug.LogWarning("Directory does not exist");
            if (!Directory.Exists(Application.persistentDataPath + subPath))
                Directory.CreateDirectory(Application.persistentDataPath + subPath);
            //File.WriteAllText(Application.persistentDataPath + subPath + "/" + name + ".csv",
            //    Resources.Load<TextAsset>("LevelInDrive/" + name).ToString());
        }

        var sheet = new ES3Spreadsheet();
        sheet.Load(Application.persistentDataPath + subPath + "/" + name + ".csv");
        // Output the first row of the spreadsheet to console.
        return sheet;
    }


    public static void SaveGoogleSheetData(string name, string contentCsv)
    {
        if (!Directory.Exists(Application.persistentDataPath + subPath))
            Directory.CreateDirectory(Application.persistentDataPath + subPath);
        File.WriteAllText(Application.persistentDataPath + subPath + "/" + name + ".csv", contentCsv);
    }

    public static void HandleDataCSV(ES3Spreadsheet sheet2)
    {

        for (int row = 2; row < sheet2.RowCount; row++)
        {

            for (int col = 0; col < sheet2.ColumnCount; col++)
            {
            }
        }
    }
}
