using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {
    private Fading fade;

    void Start()
    {
        fade = GameObject.Find("GameManager").GetComponent<Fading>();
    }

    public void LoadByIndex(int sceneIndex)
    {
        StartCoroutine(FadeWait(sceneIndex));
    }

    IEnumerator FadeWait(int sceneIndex)
    {
        float fadeTime = fade.BeginFade(1);
        Time.timeScale = 1;
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(sceneIndex);
    }
}
