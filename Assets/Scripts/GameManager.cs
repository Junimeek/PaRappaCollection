using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isLoading;
    public int currentGame;
    public int curRank;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        currentGame = 0;
        isLoading = false;
    }


}
