using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnEnter : MonoBehaviour {
    public int sceneIndex;
    private Fading fade;

    void Awake()
    {
        fade = GetComponent<Fading>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(FadeWait(sceneIndex));
    }

    IEnumerator FadeWait(int sceneIndex)
    {
        float fadeTime = fade.BeginSceneFade(1);
        fade.BeginAudioFade(1);
        Time.timeScale = 1;
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(sceneIndex);
    }
}
