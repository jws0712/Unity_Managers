using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test_1 : MonoBehaviour
{
    private void Start()
    {
        FadeManager.instance.FadeOut(null);
    }

    public void Fade()
    {
        FadeManager.instance.FadeIn(LoadNextScene);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }
}
