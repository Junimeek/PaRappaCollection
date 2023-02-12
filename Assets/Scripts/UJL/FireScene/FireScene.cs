using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;
using System.Linq;

public class FireScene : MonoBehaviour
{
    PlayerControls controls;
    
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


    private void Awake()
    {
        isSongPlaying = false;
        isMetronome = false;
        gameState = FindObjectOfType<UJL_GameState>();
        gameManager = FindObjectOfType<GameManager>();
        cutscene = FindObjectOfType<FireCutscene>();

        controls = new PlayerControls();
        controls.Gameplay.Start.performed += ctx => buttonStart();
    }

    private void Start()
    {
        StartCoroutine(OnLevelLoaded());

        gameManager.curBPM = 100;
    }

    private void buttonStart()
    {
        gameManager.isVideoPlaying = false;
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
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

    
    /*
    [SerializeField] TextAsset lammyfile;
    Dictionary<string, string> lammyclip;
    void Start()
    {
        lammyclip = new Dictionary<string, string>();
        ReadFile();
    }
    void ReadFile()
    {
        var splitFile = new string[] { "\r\n", "\r", "\n"};
        var splitLine = new char[] { ':', ',' };
        var Lines = lammyfile.text.Split(splitFile, System.StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < Lines.Length; i++)
        {
            print(Lines[i]);
            var line = Lines[i].Split(splitLine, System.StringSplitOptions.None);
            string voiceSampleID = line[0];
            string voiceSampleStart = line[1];
            string voiceSampleLength = line[2];
            lammyclip.Add(voiceSampleID, voiceSampleStart); // idk how to add a third variable
        }
    }
    */
    


    /*
    vv  Animation shit i havent figured out yet  vv


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
