using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuToStage : MonoBehaviour
{
    public Image progessBar;

    public void Awake()
    {
        progessBar.fillAmount = 1;
        NextToStage();
    }
    IEnumerator LoadAsyncOperation(int scene)
    {
        float i = progessBar.fillAmount;
        int count = 1;
        for (; i <= count && i > 0;)
        {
            i -= 5*Time.deltaTime;
            progessBar.fillAmount = i;
            yield return new WaitForSeconds(0.03f);
        }
        SceneManager.LoadScene(scene);
    }
    public void NextToStage()
    {
        StartCoroutine(LoadAsyncOperation(KeySave.SCENE_STAGE));
    }
}
