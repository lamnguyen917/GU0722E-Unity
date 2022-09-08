using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    [SerializeField] private Image progressBar;
    private bool isLoading;

    public void StartGame()
    {
        // SceneManager.LoadScene("Game");
        // SceneManager.LoadSceneAsync("Game");
        if (!isLoading)
            StartCoroutine(LoadYourAsyncScene());
    }

    private void Update()
    {
        if (isLoading && progressBar.fillAmount < 0.9f)
        {
            progressBar.fillAmount += 3f * Time.deltaTime;
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
        isLoading = true;
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Game");
        // asyncLoad.allowSceneActivation = false;

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            if (progressBar.fillAmount > 0.9f)
                progressBar.fillAmount = asyncLoad.progress;
            yield return new WaitForSeconds(0.1f);
        }

        // SceneManager.LoadScene("Game");
        asyncLoad.allowSceneActivation = true;
    }
}