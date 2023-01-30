using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
metronome script used: https://gist.github.com/bzgeb/c298c6189c73b2cf777c
*/

public class FireBeats : MonoBehaviour
{    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            QueueNextClip();
            PlayLammyClip(CurrentLammyClipQueue);
        }
    }
    
    public void QueueNextClip()
    {
        if (CurrentLammyClipQueue == 4)
        {
            CurrentLammyClipQueue = 1;
        }
        else
        {
            CurrentLammyClipQueue++;
        }
    }

    [SerializeField] AudioSource lammyclip;
    [SerializeField] private int CurrentLammyClipQueue;
    [SerializeField] float startTime;
    [SerializeField] float clipLength;
    public int[] LammyClipID;
    public float[] LammyClipStartPos;
    public float[] LammyClipLength;
    public int[] TempLammyList;

    private void InitializeLammyClip()
    {
        //LammyClipID = new int[5] {
        //    0, 1, 2, 3, 4
        //};
        TempLammyList = new int[8] {1,2,1,2,1,2,3,4};
        LammyClipStartPos = new float[5] {
            0.009f, 0.102f, 0.657f, 1.283f, 1.976f
        };
        LammyClipLength = new float[5] {
            0.080f, 0.477f, 0.561f, 0.635f, 0.758f
        };

        Debug.Log(LammyClipID[3]);
        Debug.Log(LammyClipStartPos[3]);
        Debug.Log(LammyClipLength[3]);
    }

    public void PlayLammyClip(int LammyClipCall)
    {
        if (CurrentLammyClipQueue == LammyClipCall)
        {
            startTime = LammyClipStartPos[LammyClipCall];
            clipLength = LammyClipLength[LammyClipCall];
        }
        else { return; }

        lammyclip.time = startTime;
        lammyclip.PlayScheduled(AudioSettings.dspTime);
        lammyclip.SetScheduledEndTime(AudioSettings.dspTime + clipLength);
    }
    

    [SerializeField] private AudioSource bpmtick;
    public double bpm = 140.0F;
    [SerializeField] double nextTick = 0.0F; // The next tick in dspTime
    [SerializeField] double sampleRate = 0.0F; 
    [SerializeField] bool ticked = false;
    [SerializeField] int curBeat;
    [SerializeField] int curStep;

    void Start() {
        double startTick = AudioSettings.dspTime;
        sampleRate = AudioSettings.outputSampleRate;

        nextTick = startTick + (15.0 / bpm);

        InitializeLammyClip();
    }

    void LateUpdate() {
        if ( !ticked && nextTick >= AudioSettings.dspTime) {
            ticked = true;
            BroadcastMessage( "OnTick" );
        }
    }

    void OnTick() {
        if (FindObjectOfType<FireScene>().isMetronome) {
            curStep++;
            if (curStep % 4 == 0)
            {
                curBeat++;
                bpmtick.Play();
            }
        }
    }

    public void InitializeMetronome()
    {
        double startTick = AudioSettings.dspTime;
        nextTick = startTick + (15.0 / bpm);
        curStep = 0;
        curBeat = 0;
        ticked = false;
        FindObjectOfType<FireScene>().isMetronome = true;
        bpmtick.Play();
    }

    void FixedUpdate() {
        double timePerTick = 15.0f / bpm;
        double dspTime = AudioSettings.dspTime;

        while ( dspTime >= nextTick ) {
            ticked = false;
            nextTick += timePerTick;
        }

    }
}
