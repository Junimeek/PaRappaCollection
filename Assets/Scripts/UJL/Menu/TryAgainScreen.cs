using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgainScreen : MonoBehaviour
{
    [SerializeField] private GameObject screen;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        screen.SetActive(false);
    }

    public void ShowEndScreen()
    {
        screen.SetActive(true);
    }

    public void NoClick()
    {
        FindObjectOfType<LoadingManager>().LoadScene("UJL_Initialization");
        gameManager.isTryAgain = false;
        screen.SetActive(false);
    }
}
