using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager Instance;
    public GameObject DefaultBG;
    public GameObject LammyBG;
    public float minLoadTime;
    private string targetScene;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Slider loadingBar;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        DefaultBG.SetActive(false);
        LammyBG.SetActive(false);
    }

    public void LoadScene(string sceneName)
    {
        gameManager.isLoading = true;
        targetScene = sceneName;
        StartCoroutine(LoadSceneRoutine());
    }

    [SerializeField] private AudioSource LammyLoadingLoop;

    private IEnumerator LoadSceneRoutine()
    {
        float elapsedLoadTime = 0f;
        loadingBar.value = 0f;

        if (gameManager.currentGame == 0)
        {
            DefaultBG.SetActive(true);
        }
        else if (gameManager.currentGame == 2)
        {
            LammyBG.SetActive(true);
            LammyLoadingLoop.Play();
        }

        AsyncOperation op = SceneManager.LoadSceneAsync(targetScene);

        while (!op.isDone)
        {
            elapsedLoadTime += Time.deltaTime;
            loadingBar.value += (elapsedLoadTime/minLoadTime);
            yield return null;
        }

        while (elapsedLoadTime < minLoadTime)
        {
            elapsedLoadTime += Time.deltaTime;
            loadingBar.value += (elapsedLoadTime/minLoadTime);
            yield return null;
        }


        DefaultBG.SetActive(false);
        LammyBG.SetActive(false);
        LammyLoadingLoop.Stop();
        gameManager.isLoading = false;

        StopCoroutine(LoadSceneRoutine());
    }
}
