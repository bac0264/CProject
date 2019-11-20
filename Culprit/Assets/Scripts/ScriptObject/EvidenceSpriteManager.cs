using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EvidenceSpriteManager : MonoBehaviour
{
    public static EvidenceSpriteManager instance;
    private const string SpriteName = "answer-";
    public Dictionary<string, Sprite> spriteEvidencesList = new Dictionary<string, Sprite>();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else Destroy(this);
        SetDictionary();
    }
    public void SetDictionary()
    {
        Sprite[] spriteEvidences = Resources.LoadAll<Sprite>("LevelEvidence");
        foreach (Sprite sprite in spriteEvidences)
        {
            spriteEvidencesList.Add(sprite.name, sprite);
        }
    }
    public Sprite GetSprite(int indexUnit, int indexCurScene)
    {
        try
        {
            if (spriteEvidencesList != null) return spriteEvidencesList[SpriteName + (indexUnit + 1) + "." + (indexCurScene + 1)];
            return null;
        }
        catch(Exception e)
        {
            Debug.Log(e);
            return null;
        }
    }
}
