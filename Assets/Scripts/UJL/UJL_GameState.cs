using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UJL_GameState : MonoBehaviour
{
    public int GameMode;
    private GameManager gameManager;
    private static UJL_GameState instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        gameManager = FindObjectOfType<GameManager>();
        gameManager.currentGame = 2;
    }

    public void LoadGameState(string sceneName)
    {
        FindObjectOfType<LoadingManager>().LoadScene(sceneName);
    }

    public void SetGameStateMode(int setGM)
    {
        GameMode = setGM;
    }

    public void QuitUJL()
    {
        gameManager.currentGame = 0;
        FindObjectOfType<LoadingManager>().LoadScene("Launcher");
        Destroy(gameObject);
    }
}
