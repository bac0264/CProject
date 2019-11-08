﻿using UnityEngine;
using System.Collections;

public class IncorrectPopup : BasePopup
{
    public static IncorrectPopup instance;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public override void ShowPopup()
    {
        base.ShowPopup();
    }
    public override void HidePopup()
    {
        base.HidePopup();
        if (PickupCorrectAns.instance != null) PickupCorrectAns.instance.RUN = false;
    }
    public override void Try()
    {
        base.Try();

    }
    public override void Next()
    {

    }
}
