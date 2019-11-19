using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StageUIManager : MonoBehaviour
{
    public Animator ani;
    public MenuTutorialManager tutorialManager;
    private void OnValidate()
    {
        if (ani == null) ani = GetComponent<Animator>();
    }
    public void BackMenu()
    {
        if (SoundManager.instance != null) SoundManager.instance.UI_button_Click();
        StartCoroutine(_BackMenu());
    }
    IEnumerator _BackMenu()
    {
        StageManager.instance.btns[0].GetComponent<Animator>().Play("Click");
        yield return new WaitForSeconds(KeySave.TIME_BACK);
        ani.Play("Fade");
    }
    public void NextScene()
    {
        SceneManager.LoadScene("StageToMenu");
    }
    public void Step_1_DOMoveTutorialPosition() {
        if (PlayerPrefs.GetInt(KeySave.TUTORIAL, 0) == 1)
        {
            tutorialManager.gameObject.SetActive(false);
        }
        else
        {
            tutorialManager.gameObject.SetActive(true);
            PlayerPrefs.SetInt(KeySave.TUTORIAL, 1);
        }
    }
}
