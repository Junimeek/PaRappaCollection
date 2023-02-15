using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private Boot bootloader;
    public bool isLoading;
    public bool isVideoPlaying;
    public bool isTryAgain;
    public string EnterButtonState;

    [Header("Gameplay")]
    public int currentGame;
    public int curRank;
    public int curScore;
    public float curBPM;

    void Awake()
    {
        bootloader = FindObjectOfType<Boot>();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        if (!bootloader.DebugMode)
        {
            currentGame = 0;
            curScore = 0;
            isLoading = false;
            isVideoPlaying = false;
            EnterButtonState = "Nothing";
        }
        else if (bootloader.DebugMode)
        {
            currentGame = bootloader.debugSetGame;
            curScore = 0;
            isLoading = false;
            isVideoPlaying = false;
            EnterButtonState = bootloader.debugSetEnterButton;
        }
    }
}
