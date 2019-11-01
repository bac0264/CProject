using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour
{
    public Image progessBar;
    public Text text;
    IEnumerator LoadAsyncOperation(int scene)
    {
        AsyncOperation SceneIndex = SceneManager.LoadSceneAsync(scene);
        while (!SceneIndex.isDone)
        {
            float progess = Mathf.Clamp01(SceneIndex.progress / 0.9f);
            progessBar.fillAmount = progess;
            text.text = ((int)progess * 100).ToString() + "%";
            yield return new WaitForEndOfFrame();
        }
    }
    public void NextToMenu()
    {
        StartCoroutine(LoadAsyncOperation(KeySave.SCEME_MENU));
    }
    public void NextToStage()
    {
        StartCoroutine(LoadAsyncOperation(KeySave.SCENE_STAGE));
    }
}
