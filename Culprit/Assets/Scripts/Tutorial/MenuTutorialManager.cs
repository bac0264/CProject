using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuTutorialManager : MonoBehaviour
{
    public List<MenuTutorial> Tutorials;
    public MenuTutorial currentTutorial;
    public Stage stage;

    private static MenuTutorialManager instance;
    public static MenuTutorialManager Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<MenuTutorialManager>();
            return instance;
        }
    }
    private void Update()
    {
        if (currentTutorial)
        {
            currentTutorial.CheckIfHappening();
        }
    }
    public void OpenTutorial()
    {
        MenuTutorial _tutorial_1 = GetTutorialByOrder(0);
        _tutorial_1.transform.GetChild(0).position = StageManager.instance._stageList[0].transform.position;
        _tutorial_1.gameObject.SetActive(true);
        if (StageEnhance.instance != null) StageEnhance.instance.isDOMoveTutorialPosition = true;
    }
    public MenuTutorial GetTutorialByOrder(int Order)
    {
        foreach (MenuTutorial tutorial in Tutorials)
        {
            if (tutorial.Order == Order) return tutorial;
        }
        return null;
    }
    public void SetNextTutorial(int CurOrder)
    {
        currentTutorial = GetTutorialByOrder(CurOrder);
        if (!currentTutorial)
        {
            CompletedAllTutorials();
            return;
        }
        else
        {
            currentTutorial.gameObject.SetActive(true);
        }
    }
    //
    public void CompletedAllTutorials()
    {
        gameObject.SetActive(false);
    }
    public void CompletedTutorial()
    {
        MenuTutorial tutorial = GetTutorialByOrder(currentTutorial.Order);
        tutorial.gameObject.SetActive(false);
        SetNextTutorial(currentTutorial.Order + 1);
    }
    public void Step_1()
    {
        currentTutorial = GetTutorialByOrder(0);
        if (StageManager.instance != null)
        {
            StageManager.instance.Step_1_PickupTutorial();
            currentTutorial.IsDone = true;
        }
        else gameObject.SetActive(false);
    }
    public void Step_2()
    {
        currentTutorial = GetTutorialByOrder(1);
        if (stage != null)
        {
            stage.Step_2_TutorialUnitStagePickup();
            currentTutorial.IsDone = true;
        }
        else
        {
            gameObject.SetActive(false);
        }

    }
}
