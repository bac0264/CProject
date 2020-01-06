using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour
{
    public Image progessBar;
    public Text text;

    IEnumerator LoadAsyncOperation()
    {
        AsyncOperation SceneIndex = SceneManager.LoadSceneAsync("Menu");

        while (!SceneIndex.isDone)
        {
            float progess = Mathf.Clamp01(SceneIndex.progress / 0.9f);
            progessBar.fillAmount = progess;
            text.text = ((int)(progess * 100)).ToString() + "%";
            yield return new WaitForEndOfFrame();
        }
    }
    private void Start()
    {
        StartCoroutine(LoadAsyncOperation());
    }
}