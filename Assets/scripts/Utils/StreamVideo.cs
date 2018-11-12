using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class StreamVideo : MonoBehaviour {

    public RawImage m_rawImage;
    public VideoPlayer m_videoPlayer;
    public AudioSource m_audioSource;

    // Use this for initialization
    void Start () {
        //StartCoroutine(PlayVideo());
	}

    public void Play()
    {
        StartCoroutine(PlayVideo());
    }

    public void Pause()
    {
        if (!m_videoPlayer.isPlaying)
            return;

        m_videoPlayer.Pause();
        m_audioSource.Pause();
    }

    public void BackFivePercentVideo()
    {
        ulong totalFrame = m_videoPlayer.frameCount;

        if (m_videoPlayer.frame < ConvertPercentToFrame(totalFrame, 6))
            return;

        //m_videoPlayer.frame = ConvertPercentToFrame(GetActualPercentVideo() - 5, totalFrame) {

        //}

    }

    void hh()
    {
        m_videoPlayer.frameCount
    }
	
	IEnumerator PlayVideo()
    {
        m_videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while(!m_videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        m_rawImage.texture = m_videoPlayer.texture;
        m_videoPlayer.Play();
        m_audioSource.Play();
    }

    private float ConvertPercentToFrame(int percent, int total)
    {
        return ((percent * 100f) / total) / 100f;
    }

    private int GetActualPercentVideo()
    {
        return ((m_videoPlayer.frame * 100) / m_videoPlayer.frameCount) / 100;
    }
}
