using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuToStage : MonoBehaviour
{
    public Image progessBar_1;
    public Image progessBar_2;
    public Text text;
    public GameObject container;
    public void Awake()
    {
        progessBar_1.fillAmount = 1;
        NextToStage();
    }
    IEnumerator LoadAsyncOperation(int scene)
    {
        float i = progessBar_1.fillAmount;
        int count = 1;
        for (; i <= count && i > 0;)
        {
            i -= KeySave.SMOOTH_FILLAMOUNT*Time.deltaTime;
            progessBar_1.fillAmount = i;
            yield return new WaitForSeconds(KeySave.TIME_TO_NEXT_SCENE);
        }
        container.SetActive(true);
        AsyncOperation SceneIndex = SceneManager.LoadSceneAsync(scene);

        while (!SceneIndex.isDone)
        {
            float progess = Mathf.Clamp01(SceneIndex.progress / 0.9f);
            progessBar_2.fillAmount = progess;
            text.text = ((int)(progess * 100)).ToString() + "%";
            yield return new WaitForEndOfFrame();
        }
    }
    public void NextToStage()
    {
        StartCoroutine(LoadAsyncOperation(KeySave.SCENE_STAGE));
    }
}
