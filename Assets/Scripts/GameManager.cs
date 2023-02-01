using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public bool isLoading;
    public int currentGame;
    public int curRank;
    public bool isVideoPlaying;
    public string EnterButtonState;

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
        isLoading = false;
        EnterButtonState = "Nothing";
    }


}
