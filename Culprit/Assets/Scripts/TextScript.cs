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
                text.text = LevelDataManager.instance.GetStringFromDictionary(name);
            }
            if (FontsManager.instance != null) text.font = FontsManager.instance.GetFontText(PlayerPrefs.GetInt(KeySave.LANGUAGE).ToString());
        }
        else
        {
            if (FontsManager.instance != null) text.font = FontsManager.instance.GetFontText(PlayerPrefs.GetInt(KeySave.LANGUAGE).ToString());
        }
    }
}
