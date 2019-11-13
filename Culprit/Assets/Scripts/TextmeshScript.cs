using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class TextmeshScript : MonoBehaviour
{
    public TextMeshProUGUI text;
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
        Debug.Log(LevelDataManager.instance.GetStringFromDictionary("Menu_Title"));
        if (LevelDataManager.instance != null) text.text = LevelDataManager.instance.GetStringFromDictionary(gameObject.name);
    }
}
