using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherManager : MonoBehaviour
{
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject playMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject creditsMenu;

    private GameManager gameManager;
    private LoadingManager loader;

    private void Awake()
    {
        startMenu.SetActive(true);
        playMenu.SetActive(false);
        settingsMenu.SetActive(false);
        creditsMenu.SetActive(false);

        gameManager = FindObjectOfType<GameManager>();
        loader = FindObjectOfType<LoadingManager>();
    }

    public void BackButton()
    {
        startMenu.SetActive(true);
        playMenu.SetActive(false);
        settingsMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }

    public void QuitButton()
    {
        Debug.Log("GAME QUIT");
        Application.Quit();
    }

    public void ShowPlayMenu()
    {
        playMenu.SetActive(true);
        startMenu.SetActive(false);
        FindObjectOfType<TabGroup>().TheGreatReset();
    }

    public void ShowSettingsMenu()
    {
        startMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void ShowCreditsMenu()
    {
        startMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void LaunchGame(string game)
    {
        if (game == "UJL")
        {
            loader.LoadScene("UJL_Initialization");
        }
        else
        {
            noyourafool();
        }
    }

    public void OpenLink(string thelink)
    {
        switch(thelink) {
            case "juni":
                Application.OpenURL("https://github.com/Junimeek");
                break;
            case "fry":
                Application.OpenURL("https://github.com/pahaze");
                break;
            case "git":
                Application.OpenURL("https://github.com/Junimeek/PaRappaCollection");
                break;
        }
    }

    public void noyourafool()
    {
        // You're* ???? - fry :-)
        Debug.LogError("this game doesnt exist yet you fool!");
    }

    public AudioSource RemasteredLoop;
    public AudioSource LammyLoop;
    public AudioSource SequelLoop;
    public AudioSource MenuLoop;

    public void Start()
    {
        MenuLoop.Play();
    }

    public void PlayRL()
    {
        RemasteredLoop.Play();
        LammyLoop.Stop();
        SequelLoop.Stop();
        MenuLoop.Stop();
    }
    public void PlayLL()
    {
        RemasteredLoop.Stop();
        LammyLoop.Play();
        SequelLoop.Stop();
        MenuLoop.Stop();
    }
    public void PlaySL()
    {
        RemasteredLoop.Stop();
        LammyLoop.Stop();
        SequelLoop.Play();
        MenuLoop.Stop();
    }

    public void PlayMM()
    {
        if (MenuLoop.isPlaying == false)
        {
            RemasteredLoop.Stop();
            LammyLoop.Stop();
            SequelLoop.Stop();
            MenuLoop.Play(); 
        }
        else { return; }
    }
}
