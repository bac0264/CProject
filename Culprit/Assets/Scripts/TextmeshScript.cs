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
        if (LevelDataManager.instance != null) text.text = LevelDataManager.instance.GetStringFromDictionaryUI(gameObject.name);
        if (FontsManager.instance != null)text.font = FontsManager.instance.GetFontTextMesh(PlayerPrefs.GetInt(KeySave.LANGUAGE).ToString(), type.ToString());
    }
}
