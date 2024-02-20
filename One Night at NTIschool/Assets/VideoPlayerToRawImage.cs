using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerToRawImage : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public RawImage rawImage;

    void Start()
    {
        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
    }
}
