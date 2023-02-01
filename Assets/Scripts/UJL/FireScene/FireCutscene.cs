using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using TMPro;

public class FireCutscene : MonoBehaviour
{
    [SerializeField] private GameObject renderTexture;
    [SerializeField] private GameObject levoid;
    [SerializeField] private VideoPlayer LammyCutscene;
    [SerializeField] private VideoPlayer PaRappaCutscene;
    [SerializeField] private FireScene fireScene;
    private UJL_GameState gamestate;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        gamestate = FindObjectOfType<UJL_GameState>();
    }

    private void Start()
    {
        gameManager.EnterButtonState = "SkipCutscene";
        renderTexture.SetActive(false);
        levoid.SetActive(false);
        StartCoroutine(OnLevelLoaded());
    }

    private IEnumerator OnLevelLoaded()
    {
        while (gameManager.isLoading)
        {
            yield return null;
        }

        PlayCutscene();
        StopCoroutine(OnLevelLoaded());
    }

    public void PlayCutscene()
    {
        renderTexture.SetActive(true);
        levoid.SetActive(true);
        gameManager.isVideoPlaying = true;

        if (gamestate.GameMode == 1)
        {
            LammyCutscene.Play();
            StartCoroutine(LammyEndCutscene());
        }
        else if (gamestate.GameMode == 2)
        {
            PaRappaCutscene.Play();
            StartCoroutine(PaRappaEndCutscene());
        }
        
    }

    private IEnumerator LammyEndCutscene()
    {
        while (LammyCutscene.frame < 3713 && gameManager.isVideoPlaying)
        {
            yield return null;
        }

        LammyCutscene.Stop();
        EndCutscene();
        StopCoroutine(LammyEndCutscene());
    }

    private IEnumerator PaRappaEndCutscene()
    {
        while (PaRappaCutscene.frame < 1314 && gameManager.isVideoPlaying)
        {
            yield return null;
        }

        PaRappaCutscene.Stop();
        EndCutscene();
        StopCoroutine(PaRappaEndCutscene());
    }

    private void EndCutscene()
    {
        renderTexture.SetActive(false);
        levoid.SetActive(false);
        gameManager.isVideoPlaying = false;
    }
}
