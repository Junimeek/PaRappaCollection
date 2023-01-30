using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class FireCutscene : MonoBehaviour
{
    [SerializeField] private GameObject renderTexture;
    [SerializeField] private GameObject levoid;
    [SerializeField] private VideoPlayer Cutscene;

    private void Start()
    {
        renderTexture.SetActive(false);
        levoid.SetActive(false);
    }

    public void PlayCutscene()
    {
        renderTexture.SetActive(true);
        levoid.SetActive(true);
        Cutscene.Play();
        StartCoroutine(EndCutscene());
    }

    private IEnumerator EndCutscene()
    {
        while (Cutscene.frame < 3713 && FindObjectOfType<FireScene>().isVideoPlaying == true)
        {
            yield return null;
        }

        renderTexture.SetActive(false);
        levoid.SetActive(false);
        Cutscene.Stop();
    }
}
