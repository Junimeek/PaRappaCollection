using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boot : MonoBehaviour
{
    [SerializeField] private float DelayedBootTime;

    [Header("Debugging")]
    public bool DebugMode;

    [Tooltip("Only use this if you are NOT just dragging the GloabalState scene into the heirarchy of another scene.")]
    public bool ForceSceneLoad;
    [Tooltip("0 = Launcher | 1 = PTRR | 2 = UJL | 3 = PTR2")]
    public int debugSetGame;
    public string debugSetEnterButton;
    [Tooltip("If ForceSceneLoad is enabled, this scene will be loaded.")]
    public string debugSceneLoad;
    
    private void Start()
    {
        InvokeLeBoot(DelayedBootTime, debugSceneLoad);
    }

    private void InvokeLeBoot(float delay, string scene)
    {
        string delaytime = delay.ToString();

        if (delay > 0 && !DebugMode)
        {
            Invoke("DelayedBoot", delay);
            Debug.LogWarning("Bootloader has a delay applied before the game launches. Please wait " + delaytime + " seconds.");
        }
        else if (DebugMode && ForceSceneLoad)
        {
            Debug.LogWarning("If you are seeing this message AND there is no scene loaded, please disable Debug Mode.");
            FindObjectOfType<LoadingManager>().LoadScene(scene);
            Destroy(this.gameObject);
        }
        else if (DebugMode && !ForceSceneLoad)
        {
            Debug.LogWarning("If you are seeing this message AND there is no scene loaded, please disable Debug Mode.");
            Destroy(this.gameObject);
        }
    }

    private void DelayedBoot()
    {
        if (!DebugMode)
        {
            Debug.Log("LOADING Launcher");
            SceneManager.LoadSceneAsync("Launcher");
        }
        else if (DebugMode)
        {
            Debug.LogError("Debug Mode is active! Disable debug mode to continue.");
        }
    }
}
