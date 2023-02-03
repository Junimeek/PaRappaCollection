using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UJL_GameState : MonoBehaviour
{
    public int GameMode;
    [SerializeField] private GameManager gameManager;
    private static UJL_GameState instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            gameManager = FindObjectOfType<GameManager>();
            gameManager.currentGame = 2;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    public void SetGameStateMode(int setGM)
    {
        GameMode = setGM;
    }
}
