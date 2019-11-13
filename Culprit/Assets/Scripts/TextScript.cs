using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public Text text;
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
        if (LevelDataManager.instance != null) text.text = LevelDataManager.instance.GetStringFromDictionary(name);
        if (FontsManager.instance != null) text.font = FontsManager.instance.GetFontText(PlayerPrefs.GetInt(KeySave.LANGUAGE).ToString());
    }
}
