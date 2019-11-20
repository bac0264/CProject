using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVComingSoonPopup : BasePopup
{
    public static LVComingSoonPopup instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
}
