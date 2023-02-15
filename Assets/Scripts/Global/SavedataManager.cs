using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedataManager : MonoBehaviour
{
    private static SavedataManager instance;
    public string CurrentGame;
    public string SongPath;
    public string DataPath;

    /*
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    */

    [SerializeField] private ChartData _SongData = new ChartData();
    public void SaveIntoJson(){
        string song = JsonUtility.ToJson(_SongData);
        System.IO.File.WriteAllText(Application.dataPath + "/GameData/" + CurrentGame + "/" + SongPath + "/" + SongPath + "-data.json", song);
    }
}

[System.Serializable]
public class ChartData{
    public string songAssetPath;
    public string songDataPath;
    public float bpm;
    public List<Notes> notes = new List<Notes>();
}

[System.Serializable]
public class Notes{
    public int note;
    public int sound;
    public int step;
    public bool mustHit;
}
