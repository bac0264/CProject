using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class TextmeshScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    public enum TypeTextMesh
    {
        Btn = 1,
        Setting = 2,
        Lose = 3
    }
    public TypeTextMesh type;
    private void Start()
    {
        if (text == null) text = GetComponent<TextMeshProUGUI>();
        UpdateText();
    }
    private void OnValidate()
    {
        if (text == null) text = GetComponent<TextMeshProUGUI>();
    }
    public void UpdateText()
    {
        if (LevelDataManager.instance != null)
        {
            string data = "#$%^#$^";
            try
            {
                data = LevelDataManager.instance.GetStringFromDictionaryUI(name);
            }
            catch
            {
            }
            if (!data.Equals(" "))
            {
                ReplaceText.replaceText(data);
                text.text = data;
            }
        }
        if (FontsManager.instance != null) text.font = FontsManager.instance.GetFontTextMesh(PlayerPrefs.GetInt(KeySave.LANGUAGE).ToString(), type.ToString());
    }
}
public class ReplaceText
{
    public static string replaceText(string data){
        string x = "'";
        char _x = x[0];
        if (data == null) return " ";
        data = data.Replace(';', ',');
        data = data.Replace('/', _x);
        data = data.Replace("AAA", "-");
        data = data.Replace("BBB", "'");
        return data;
    }
}

