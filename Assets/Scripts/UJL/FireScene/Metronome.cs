using UnityEngine;
using System.Collections;

public class Metronome : MonoBehaviour
{
    [SerializeField] private AudioSource bpmtick;
    public double bpm = 140.0F;

    [SerializeField] double nextTick = 0.0F; // The next tick in dspTime
    [SerializeField] double sampleRate = 0.0F; 
    [SerializeField] bool ticked = false;

    void Start() {
        double startTick = AudioSettings.dspTime;
        sampleRate = AudioSettings.outputSampleRate;

        nextTick = startTick + (60.0 / bpm);
    }

    void LateUpdate() {
        if ( !ticked && nextTick >= AudioSettings.dspTime ) {
            ticked = true;
            BroadcastMessage( "OnTick" );
        }
    }

    // Just an example OnTick here
    void OnTick() {
        bpmtick.Play();
    }

    void FixedUpdate() {
        double timePerTick = 60.0f / bpm;
        double dspTime = AudioSettings.dspTime;

        while ( dspTime >= nextTick ) {
            ticked = false;
            nextTick += timePerTick;
        }
    }
}