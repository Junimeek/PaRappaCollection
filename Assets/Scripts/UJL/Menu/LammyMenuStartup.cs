using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LammyMenuStartup : MonoBehaviour
{
    [SerializeField] private AudioSource TitleLoop;
    [SerializeField] private VideoPlayer Logo;
    [SerializeField] private VideoPlayer Title;
    [SerializeField] private GameObject levoid;
    [SerializeField] private GameObject videoTexture;
    private UJL_GameState lammygamestate;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        lammygamestate = FindObjectOfType<UJL_GameState>();
    }

    public void Start()
    {
        StartCoroutine(OnLevelLoaded());
        gameManager.EnterButtonState = "SkipCutscene";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && gameManager.EnterButtonState == "SkipCutscene")
        {
            gameManager.isVideoPlaying = false;
        }
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
        gameManager.isVideoPlaying = true;
        levoid.SetActive(true);
        videoTexture.SetActive(true);
        Logo.Play();

        while (Logo.frame < 205 && gameManager.isVideoPlaying)
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

        while (Title.frame < 318 && gameManager.isVideoPlaying)
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
        while (Title.frame < 341 && gameManager.isVideoPlaying)
        {
            yield return null;
        }

        Title.Stop();
        StopVideo();
        StopCoroutine(EndTitle());
    }

    private void StopVideo()
    {
        gameManager.isVideoPlaying = false;
        TitleLoop.Play();
    }

    public void QuitUJL()
    {
        gameManager.currentGame = 0;
        FindObjectOfType<LoadingManager>().LoadScene("Launcher");
        Destroy(lammygamestate.gameObject);
    }

    public void LoadGameState(string sceneName)
    {
        FindObjectOfType<LoadingManager>().LoadScene(sceneName);
    }

    public void SetGameStateMode(int setGM)
    {
        FindObjectOfType<UJL_GameState>().SetGameStateMode(setGM);
    }

    public void SetBPM(float BPM)
    {
        gameManager.curBPM = BPM;
    }
}
