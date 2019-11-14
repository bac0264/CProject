using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StageUIManager : MonoBehaviour
{
    public Animator ani;
    private void OnValidate()
    {
        if (ani == null) ani = GetComponent<Animator>();
    }
    public void BackMenu()
    {
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
}
