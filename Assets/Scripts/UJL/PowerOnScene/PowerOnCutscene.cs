using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PowerOnCutscene : MonoBehaviour
{
    [SerializeField] private Animation PaRappaCutsceneVideo;
    [SerializeField] private GameObject PaRappaCutsceneObject;
    [SerializeField] private AudioSource PaRappaCutsceneAudio;
    private UJL_GameState gamestate;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        gamestate = FindObjectOfType<UJL_GameState>();
    }

    private void Start()
    {
        StartCoroutine(OnLevelLoaded());
        PaRappaCutsceneVideo.Stop();
        PaRappaCutsceneObject.SetActive(false);
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
        gameManager.isVideoPlaying = true;

        if (gamestate.GameMode == 2)
        {
            PaRappaCutsceneObject.SetActive(true);
            PaRappaCutsceneVideo.Play();
            PaRappaCutsceneAudio.Play();
            StartCoroutine(PaRappaEndCutscene());
        }
    }

    private IEnumerator PaRappaEndCutscene()
    {
        while (gameManager.isVideoPlaying)
        {
            yield return null;
        }

        PaRappaCutsceneVideo.Stop();
        PaRappaCutsceneAudio.Stop();
        PaRappaCutsceneObject.SetActive(false);
        EndCutscene();
        StopCoroutine(PaRappaEndCutscene());
    }

    private void EndCutscene()
    {
        gameManager.isVideoPlaying = false;
    }
}
