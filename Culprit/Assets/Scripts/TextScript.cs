using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public Text text;
    public enum TypeofText
    {
        Static,
        Dynamic
    }
    public TypeofText type;
    private void Start()
    {
        if (text == null) text = GetComponent<Text>();
        UpdateText();
    }
    private void OnValidate()
    {
        if (text == null) text = GetComponent<Text>();
    }
    public void UpdateText()
    {
        if (type == TypeofText.Static)
        {
            if (LevelDataManager.instance != null)
            {
                string data = LevelDataManager.instance.GetStringFromDictionaryUI(name);
                if (data.Equals(" ")) return;
                else
                {
                    string x = "'";
                    char _x = x[0];
                    data = data.Replace(';', ',');
                    data = data.Replace('\\', _x);
                    text.text = data;
                }
            }
            if (FontsManager.instance != null) text.font = FontsManager.instance.GetFontText(PlayerPrefs.GetInt(KeySave.LANGUAGE).ToString());
        }
        else
        {
            if (FontsManager.instance != null) text.font = FontsManager.instance.GetFontText(PlayerPrefs.GetInt(KeySave.LANGUAGE).ToString());
        }
    }
}
