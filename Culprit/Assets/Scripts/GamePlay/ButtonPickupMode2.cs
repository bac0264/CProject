using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ButtonPickupMode2 : MonoBehaviour
{
    public static ButtonPickupMode2 instance;
    private const int defaultSprite = 0;
    private const int passed = 1;
    private const int current = 2;
    public List<Button> btnScenes;
    public Transform BtnContainer;
    public Sprite[] spriteList;
    public Animator ani;
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
        int i = 0;
        Debug.Log(unitMode2.AmountofAsk);
        for ( ; i < btnScenes.Count && i <= unitMode2.AmountofAsk; i++)
        {
            if (i == 0) SetBtnSceneDisplay(unitMode2, i);
            int z = i;
            btnScenes[z].onClick.RemoveAllListeners();
            btnScenes[z].onClick.AddListener(delegate { SetBtnSceneDisplay(unitMode2, z); });
            btnScenes[z].gameObject.SetActive(true);
        }
        for (; i < btnScenes.Count ; i++)
        {
            btnScenes[i].gameObject.SetActive(false);
        }
    }

    public void SetBtnSceneDisplay(UnitMode2 unitMode2, int _index)
    {
        unitMode2.CurIndexScene = _index;
        if (_index <= unitMode2.MaxIndexScene)
        {
            int i = 0;
            for (; i < btnScenes.Count; i++)
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
                    if (unitMode2.isWin) {
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
            if (PopupFactory.instance != null) PopupFactory.instance.ShowPopup(BasePopup.TypeOfPopup.PO_Question );
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
    public void SetupAnimator()
    {

    }
    public void QuestionBtn()
    {
        if (SoundManager.instance != null) SoundManager.instance.UI_button_Click();
        if (PopupFactory.instance != null) PopupFactory.instance.ShowPopup(BasePopup.TypeOfPopup.PO_Question);
    }
    public void HintBtn()
    {
        if (SoundManager.instance != null) SoundManager.instance.UI_button_Click();
        if (PopupFactory.instance != null)
        {
            PopupFactory.instance.ShowPopup(BasePopup.TypeOfPopup.PO_Hint);
            PlayerPrefs.SetInt(KeySave.HINT, 1);
        }
    }
}
