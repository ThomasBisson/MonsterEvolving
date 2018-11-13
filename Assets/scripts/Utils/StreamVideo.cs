using System;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            Play();
        if (Input.GetKeyDown(KeyCode.L))
            Pause();
        if (Input.GetKeyDown(KeyCode.M))
            BackPercentVideo(5);
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

    public void BackPercentVideo(ulong percent)
    {
        ulong totalFrame = m_videoPlayer.frameCount;
        ulong actualFrame = Convert.ToUInt64(m_videoPlayer.frame);

        if (actualFrame < MathUtils.PercentValueFromAnotherValue(percent, totalFrame))
            return;
        m_videoPlayer.frame = Convert.ToInt64(MathUtils.PercentValueFromAnotherValue(MathUtils.PercentValueFromAnotherValue(actualFrame, totalFrame) - percent, totalFrame));
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
}
