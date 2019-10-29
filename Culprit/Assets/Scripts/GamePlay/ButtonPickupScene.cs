using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ButtonPickupScene : MonoBehaviour
{
    public static ButtonPickupScene instance;
    private const int defaultSprite = 0;
    private const int passed = 1;
    private const int current = 2;
    public List<Button> btnScenes;
    public Transform BtnContainer;
    public Sprite[] spriteList;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public void OnValidate()
    {

        if (btnScenes.Count == 0)
        {
            for (int i = 0; i < BtnContainer.childCount; i++)
            {
                btnScenes.Add(BtnContainer.GetChild(i).GetComponent<Button>());
            }
        }
    }
    public void SetupBtnDelegate(UnitMode2 unitMode2)
    {
        for (int i = 0; i < btnScenes.Count; i++)
        {
            if (i == 0) SetBtnSceneDisplay(unitMode2, i);
            int z = i;
            btnScenes[z].onClick.AddListener(delegate { SetBtnSceneDisplay(unitMode2, z); });
        }
    }

    public void SetBtnSceneDisplay(UnitMode2 unitMode2, int _index)
    {
        unitMode2.CurIndexScene = _index;
        if (_index <= unitMode2.MaxIndexScene)
        {
            for (int i = 0; i < btnScenes.Count; i++)
            {
                if (i == _index)
                {
                    btnScenes[i].transform.GetChild(0).gameObject.SetActive(true);
                    unitMode2.correctAnswerBtns[i].gameObject.SetActive(true);
                }
                else
                {
                    btnScenes[i].transform.GetChild(0).gameObject.SetActive(false);
                    unitMode2.correctAnswerBtns[i].gameObject.SetActive(false);
                }
                if (i < unitMode2.MaxIndexScene)
                {
                    btnScenes[i].GetComponent<Image>().sprite = spriteList[passed];
                }
                else if (i == unitMode2.MaxIndexScene)
                {
                    if (unitMode2.MaxIndexScene == (unitMode2.correctAnswerBtns.Count -1)) {
                        btnScenes[i].GetComponent<Image>().sprite = spriteList[passed];
                    }
                    else
                    btnScenes[i].GetComponent<Image>().sprite = spriteList[current];
                }
                else
                {
                    btnScenes[i].GetComponent<Image>().sprite = spriteList[defaultSprite];
                }
            }
        }
    }
    public void OpenBtn(int index)
    {
        btnScenes[index].GetComponent<Image>().sprite = spriteList[current];
        btnScenes[index].transform.GetChild(0).gameObject.SetActive(true);
    }
    public void CloseBtn(int index)
    {
        btnScenes[index].GetComponent<Image>().sprite = spriteList[passed];
        btnScenes[index].transform.GetChild(0).gameObject.SetActive(false);
    }
}
