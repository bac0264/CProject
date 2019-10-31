using UnityEngine;
using System.Collections;
[CreateAssetMenu(fileName = "LevelEvidence", menuName = "MENU/LevelEvidence", order = 1) ]
public class LevelEvidenceSprites : ScriptableObject
{
    public Sprite[] spriteEvidences;

    public void OnEnable()
    {
        Debug.Log("run");
        if (spriteEvidences.Length == 0) spriteEvidences = Resources.LoadAll<Sprite>("LevelEvidence");
    }
    public Sprite GetSprite(int indexUnit, int indexCurScene)
    {
        return spriteEvidences[indexUnit*4 + indexCurScene];
    }
}
