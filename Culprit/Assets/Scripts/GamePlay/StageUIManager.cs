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
        ani.Play("Fade");
    }
    public void NextScene()
    {
        SceneManager.LoadScene("StageToMenu");
    }
}
