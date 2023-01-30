using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class FireScene : MonoBehaviour
{
    [SerializeField] private AudioSource LammyFireInstGood;
    [SerializeField] private AudioSource LammyFireVoices;
    [SerializeField] private GameObject DebugInstructions;
    public bool isSongPlaying;
    public bool isMetronome;
    public bool isVideoPlaying;

    private void Awake()
    {
        isSongPlaying = false;
        isMetronome = false;
    }

    public void BeginFireSong()
    {
        LammyFireInstGood.Play();
    }
    public void EndFireSong()
    {
        LammyFireInstGood.Stop();
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
        
        if (isVideoPlaying == false && Input.GetKeyDown(KeyCode.V))
        {
            isVideoPlaying = true;
            FindObjectOfType<FireCutscene>().PlayCutscene();
        }
        else if (isVideoPlaying == true && Input.GetKeyDown(KeyCode.V))
        {
            isVideoPlaying = false;
        }
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
