using UnityEngine;
using UnityEngine.Video;

public class UJL_VideoPlayer : MonoBehaviour
{
    private VideoPlayer player;
    public GameObject VideoPlayer;
    public void PlayVideo()
    {
        VideoPlayer.SetActive(true);
        player = GetComponent<VideoPlayer>();
        player.clip = Resources.Load<VideoClip>("LOGO");
    }
}
