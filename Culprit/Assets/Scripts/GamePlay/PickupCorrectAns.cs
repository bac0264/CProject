using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using Spine.Unity;

public class PickupCorrectAns : MonoBehaviour
{
    public static PickupCorrectAns instance;
    public Camera _camera;
    public Animator ani;
    public Transform correctPosition;
    public Vector3 pos;
    public bool run;
    private bool isCorrect;
    private bool isShowFull;
    public bool RUN
    {
        set
        {
            run = value;
        }
        get
        {
            return run;
        }
    }
    public bool ISCORRECT
    {
        set
        {
            isCorrect = value;
        }
        get
        { return isCorrect; }
    }
    public bool ISSHOWFULL
    {
        set
        {
            isShowFull = value;
        }
        get
        { return isShowFull; }
    }
    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && !RUN)
        {
            pos = _camera.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            correctPosition.DOMove(pos, 0);
        }
    }

    private void Awake()
    {
        RUN = false;
        if (instance == null) instance = this;
    }
    public void RunPickup()
    {
        //correctPosition.localPosition = pos;
        if (SoundManager.instance != null) SoundManager.instance.UI_effect_Pick();
        Hide_Tutorial();
        RUN = true;
        ani.Play("Run");
    }
    public void StartAnima()
    {
        correctPosition.gameObject.SetActive(true);
    }
    public void Stickman_Whoosh()
    {
        if (SoundManager.instance != null) SoundManager.instance.UI_effect_Whoosh();
    }
    public void FinishAnima()
    {
        correctPosition.gameObject.SetActive(false);
    }
    public void EventShowAds()
    {
        if(ISSHOWFULL == false)
        {

        }
        else
        {
            if (IronSourceManager.instance != null) IronSourceManager.instance.ShowInterstitial();
            ISSHOWFULL = false;
        }
    }
    public void EventShowCorrectPopup()
    {
        if (isCorrect == false)
        {
            if (PopupFactory.instance != null) PopupFactory.instance.ShowPopup(BasePopup.TypeOfPopup.PO_Incorrect);
        }
        else
        {
            if (PopupFactory.instance != null) PopupFactory.instance.ShowPopup(BasePopup.TypeOfPopup.PO_Correct);
        }
        isCorrect = false;
    }
    public void Rebind()
    {
        ani.Rebind();
    }

    public SkeletonGraphic pickup_Tutorial;

    public void Show_Tutorial()
    {
        StartCoroutine(show_Tutorial());
    }
    IEnumerator show_Tutorial()
    {
        if (PlayerPrefs.GetInt(KeySave.TUTORIAL_PICKUP, 0) == 0)
        {
            PlayerPrefs.SetInt(KeySave.TUTORIAL_PICKUP, 1);
            if (StageManager.instance != null)
            {
                Unit unit = ButtonStageManager.instance.stage.GetUnitStage(0).unit;
                if (unit is UnitMode2)
                {
                    UnitMode2 _unitMode2 = unit as UnitMode2;
                    Vector3 _pos = _unitMode2.correctAnswerBtns[0].transform.position;
                    pickup_Tutorial.transform.position = _pos;
                    pickup_Tutorial.gameObject.SetActive(true);
                    yield return new WaitForSeconds(2f); ;
                    pickup_Tutorial.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            pickup_Tutorial.gameObject.SetActive(false);
        }
    }
    public void Hide_Tutorial()
    {
        pickup_Tutorial.gameObject.SetActive(false);
    }
}
