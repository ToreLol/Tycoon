using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    //Black Screen
    public Image BlackBG;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    //Loads a new Scene Function
    public void LoadScene(int _scene)
    {
        StartCoroutine(FadeOut(_scene));
    }

    //Exits Application Function
    public void Exit()
    {
        Application.Quit();
    }

    IEnumerator FadeIn()
    {
        Color c = BlackBG.color;
        for (float alpha = 1f; alpha >= 0f;alpha -= 1f * Time.deltaTime)
        {
            c.a = alpha;
            BlackBG.color = c;
            yield return null;
        }
    }

    IEnumerator FadeOut(int _scene)
    {
        Color c = BlackBG.color;
        for (float alpha = 0f; alpha <= 1f; alpha += 1f * Time.deltaTime)
        {
            c.a = alpha;
            BlackBG.color = c;
            yield return null;
        }

        //Change Scene
        SceneManager.LoadScene(_scene);
    }
}
