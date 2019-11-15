﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class PickupCorrectAns : MonoBehaviour
{
    public static PickupCorrectAns instance;
    public Camera _camera;
    public Animator ani;
    public Transform correctPosition;
    public Vector3 pos;
    public bool run;
    private bool isCorrect;
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
        RUN = true;
        ani.Play("Run");
    }
    public void StartAnima()
    {
        correctPosition.gameObject.SetActive(true);
    }
    public void FinishAnima()
    {
        correctPosition.gameObject.SetActive(false);
    }
    public void EventShowCorrectPopup()
    {
        Debug.Log("run");
        if (isCorrect == false)
        {
            if (PopupFactory.instance != null) PopupFactory.instance.GetPopup(BasePopup.TypeOfPopup.PO_Incorrect);
        }
        else
        {
            if (PopupFactory.instance != null) PopupFactory.instance.GetPopup(BasePopup.TypeOfPopup.PO_Correct);
        }
        isCorrect = false;
    }
    public void Rebind()
    {
        ani.Rebind();
    }
}
