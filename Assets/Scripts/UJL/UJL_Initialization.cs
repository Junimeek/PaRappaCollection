using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UJL_Initialization : MonoBehaviour
{
    [SerializeField] private AudioSource TitleLoop;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private VideoPlayer Logo;
    [SerializeField] private VideoPlayer Title;
    [SerializeField] private GameObject levoid;
    [SerializeField] private GameObject videoTexture;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void Start()
    {
        gameManager.currentGame = 2;
        StartCoroutine(OnLevelLoaded());
    }

    public void LoadGameState(string sceneName)
    {
        FindObjectOfType<LoadingManager>().LoadScene(sceneName);
    }

    private IEnumerator OnLevelLoaded()
    {
        while (gameManager.isLoading == true)
        {
            yield return null;
        }

        StartCoroutine(PlayLogo());
        StopCoroutine(OnLevelLoaded());
    }

    private IEnumerator PlayLogo()
    {
        levoid.SetActive(true);
        videoTexture.SetActive(true);
        Logo.Play();

        while (Logo.frame < 205)
        {
            yield return null;
        }

        Logo.Stop();
        StartCoroutine(BeginTitle());
        StopCoroutine(PlayLogo());
    }

    private IEnumerator BeginTitle()
    {
        Title.Play();

        while (Title.frame < 318)
        {
            yield return null;
        }

        videoTexture.SetActive(false);
        levoid.SetActive(false);
        StartCoroutine(EndTitle());
        StopCoroutine(BeginTitle());
    }

    private IEnumerator EndTitle()
    {
        while (Title.frame < 341)
        {
            yield return null;
        }

        Title.Stop();
        TitleLoop.Play();
        StopCoroutine(EndTitle());
    }
}
