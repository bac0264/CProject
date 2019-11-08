using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PickupCorrectAns : MonoBehaviour
{
    public static PickupCorrectAns instance;

    public Animator ani;
    public Transform correctPosition;
    private bool correct;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public void Run(Vector3 correctPos)
    {
        Debug.Log("run");
        DOTween.KillAll();
        correctPosition.DOMove(correctPos, 0);
        ani.Play("Run");
    }
    public void EventShowCorrectPopup()
    {
        Debug.Log("run");
        if (PopupContainer.instance != null) PopupContainer.instance.ShowCorrectPopup();
    }
}
