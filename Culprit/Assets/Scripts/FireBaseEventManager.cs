using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Analytics;

public class FireBaseEventManager : MonoBehaviour
{
    public static FireBaseEventManager instance;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


    public void PostLoadToTut1()
    {
        FirebaseAnalytics.LogEvent("LoadToTutotial_1");
    }
}
