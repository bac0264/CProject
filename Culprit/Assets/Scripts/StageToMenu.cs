using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageToMenu : MonoBehaviour
{
    public Image progessBar;

    public void Awake()
    {
        progessBar.fillAmount = 1;
        NextToMenu();
    }
    IEnumerator LoadAsyncOperation(int scene)
    {
        float i = progessBar.fillAmount;
        int count = 1;
        for (; i <= count && i > 0;)
        {
            i -= KeySave.SMOOTH_FILLAMOUNT * Time.deltaTime;
            progessBar.fillAmount = i;
            yield return new WaitForSeconds(KeySave.TIME_TO_NEXT_SCENE);
        }
        SceneManager.LoadScene(scene);
    }
    public void NextToMenu()
    {
        StartCoroutine(LoadAsyncOperation(KeySave.SCEME_MENU));
    }
}
