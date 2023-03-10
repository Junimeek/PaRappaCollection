using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;
using System.Linq;

public class FireScene : MonoBehaviour
{
    public bool isSongPlaying;
    public bool isMetronome;

    private GameManager gameManager;
    private FireCutscene cutscene;
    private UJL_GameState gameState;

    [Header("Audio")]
    [SerializeField] private AudioSource LammyFireInstGood;
    [SerializeField] private AudioSource PaRappaFireInstGood;
    [SerializeField] private AudioSource LammyFireVoices;
    [SerializeField] private GameObject DebugInstructions;

    [SerializeField] TextAsset lammyfile;
    Dictionary<string, string> lammyclip;

    private void Awake()
    {
        isSongPlaying = false;
        isMetronome = false;
        gameState = FindObjectOfType<UJL_GameState>();
        gameManager = FindObjectOfType<GameManager>();
        cutscene = FindObjectOfType<FireCutscene>();
    }

    private void Start()
    {
        gameManager.curBPM = 100f;
        StartCoroutine(OnLevelLoaded());

        // fry note: lammyclip needs to be updated, will do this later :) 
        lammyclip = new Dictionary<string, string>();
        FileReader.ReadVoicesAsset(lammyfile, lammyclip);
    }

    public void BeginFireSong()
    {
        if (gameState.GameMode == 1)
        {
            LammyFireInstGood.Play();
        }
        else if (gameState.GameMode == 2)
        {
            PaRappaFireInstGood.Play();
        }
    }
    public void EndFireSong()
    {
        LammyFireInstGood.Stop();
        PaRappaFireInstGood.Stop();
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            DebugInstructions.SetActive(true);
        }
        else
        {
            DebugInstructions.SetActive(false);
        }

        /*
        if (isSongPlaying == false && Input.GetKeyDown(KeyCode.Z))
        {
            BeginFireSong();
            isSongPlaying = true;
        }
        else if (isSongPlaying == true && Input.GetKeyDown(KeyCode.Z))
        {
            EndFireSong();
            isSongPlaying = false;
        }
        */

        if (isMetronome == false && Input.GetKeyDown(KeyCode.X))
        {
            GetComponent<FireBeats>().InitializeMetronome();
        }
        else if (isMetronome == true && Input.GetKeyDown(KeyCode.X))
        {
            isMetronome = false;
        }
        
        /*
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (gameManager.EnterButtonState == "SkipCutscene")
            {
                gameManager.isVideoPlaying = false;
            }
            else if (gameManager.EnterButtonState == "EndGame")
            {
                LammyFireInstGood.Stop();
                PaRappaFireInstGood.Stop();
                gameManager.EnterButtonState = "Nothing";
                FindObjectOfType<TryAgainScreen>().ShowEndScreen();
            }
        }
        */
    }

    private IEnumerator OnLevelLoaded()
    {
        while (gameManager.isLoading)
        {
            yield return null;
        }

        StartCoroutine(OnCutsceneEnd());
        StopCoroutine(OnLevelLoaded());
    }

    private IEnumerator OnCutsceneEnd()
    {
        gameManager.isVideoPlaying = true;

        while (gameManager.isVideoPlaying)
        {
            yield return null;
        }

        gameManager.EnterButtonState = "EndGame";
        BeginFireSong();
        StopCoroutine(OnCutsceneEnd());
    }

    void OnButtonStart(InputValue value)
    {
        if (value.isPressed)
        {
            gameManager.isVideoPlaying = false;
        }
    }

    void OnDebugSong(InputValue value)
    {
        if (value.isPressed)
        {
            if (isSongPlaying == false)
            {
                BeginFireSong();
                isSongPlaying = true;
            }
            else if (isSongPlaying == true)
            {
                EndFireSong();
                isSongPlaying = false;
            }
        }
    }

    /*
    vv  Animation bs i havent figured out yet  vv

    public Animator good;
    private int rank = FindObjectOfType<GameManager>().curRank;

    void Start()
    {
        this.good.SetTrigger("idle");
    }

    void Update()
    {
        if ( rank == 3 )
        {
            this.good.SetTrigger("idle");
        }
        else if ( rank == 4 || rank == 5 )
        {
            this.good.SetTrigger("flash");
        }
        else if (rank == 6)
        {
            this.good.SetTrigger("dim");
        }
    }
    */
}
