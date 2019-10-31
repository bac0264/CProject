using UnityEngine;
using System.Collections;
[CreateAssetMenu(fileName = "LevelEvidence", menuName = "MENU/LevelEvidence", order = 1) ]
public class LevelEvidenceSprites : ScriptableObject
{
    public Sprite[] spriteEvidences;

    private void OnEnable()
    {
        if (spriteEvidences.Length == 0) spriteEvidences = Resources.LoadAll<Sprite>("LevelEvidence");
    }
}
