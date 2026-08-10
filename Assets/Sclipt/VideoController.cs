using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [SerializeField] private RawImage rawImage;
    [SerializeField] private VideoPlayer videoPlayer;

    private void Start()
    {
        // 最初は動画画面を隠す
        rawImage.enabled = false;

        // 動画終了時の処理
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    // UnityEventから呼ぶ
    public void PlayVideo()
    {
        // 動画画面を表示
        rawImage.enabled = true;

        // 動画を最初から再生
        videoPlayer.Stop();
        videoPlayer.Play();
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        // 動画が終わったら画面を隠す
        rawImage.enabled = false;
    }
}