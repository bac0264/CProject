using UnityEngine;
using System.Collections;
[CreateAssetMenu(fileName = "LevelEvidence", menuName = "MENU/LevelEvidence", order = 1)]
public class LevelEvidenceSprites : ScriptableObject
{
    private const string SpriteName = "answer-";
    public Sprite[] spriteEvidences;
    public void OnEnable()
    {
        spriteEvidences = Resources.LoadAll<Sprite>("LevelEvidence");
        //
    }

    public Sprite GetSprite(int indexUnit, int indexCurScene)
    {
        foreach(Sprite sprite in spriteEvidences)
        {
            if (sprite.name.Equals(SpriteName + (indexUnit + 1) + "." + (indexCurScene+1))) return sprite;
        }
        return null;
    }
}
