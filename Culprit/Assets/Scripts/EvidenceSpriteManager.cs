using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class LevelEvidenceSprites : MonoBehaviour
{
    public static LevelEvidenceSprites instance;
    private const string SpriteName = "answer-";
    //public Dictionary<string, Sprite> spriteEvidencesList = new Dictionary<string, Sprite>();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else Destroy(this);
       // SetDictionary();
    }
    //public void SetDictionary()
    //{
    //    Sprite[] spriteEvidences = Resources.LoadAll<Sprite>("LevelEvidence");
    //    foreach (Sprite sprite in spriteEvidences)
    //    {
    //        spriteEvidencesList.Add(sprite.name, sprite);
    //    }
    //}
    public Sprite GetSprite(int indexUnit, int indexCurScene)
    {
        try
        {
            string link = "LevelEvidence/" + SpriteName + (indexUnit + 1) + "." + (indexCurScene + 1);
            Sprite spriteEvidences = Resources.Load<Sprite>(link);
            if (spriteEvidences != null) return spriteEvidences;
            return null;
        }
        catch(Exception e)
        {
            Debug.Log(e);
            return null;
        }
    }
}
