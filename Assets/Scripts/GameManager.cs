using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public bool isLoading;
    public bool isVideoPlaying;
    public bool isTryAgain;
    public string EnterButtonState;

    [Header("Gameplay")]
    public int currentGame;
    public int curRank;
    public int curScore;
    

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        currentGame = 0;
        curScore = 0;
        isLoading = false;
        isVideoPlaying = false;
        EnterButtonState = "Nothing";
    }
}
