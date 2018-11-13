using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class StreamVideo : MonoBehaviour {

    /************* VIDEO PLAYER *************/
    [SerializeField]
    private RawImage m_rawImage;
    [SerializeField]
    private VideoPlayer m_videoPlayer;
    [SerializeField]
    private AudioSource m_audioSource;


    /************* VIDEO CONTROLLER *************/
    [SerializeField]
    private Slider m_slider;
    [SerializeField]
    private Image m_imagePlayButton;
    [SerializeField]
    private Sprite m_playIcon;
    [SerializeField]
    private Sprite m_pauseIcon;

    #region UNITY_METHODES
    // Use this for initialization
    void Start () {
        StartCoroutine(PrepareVideo());
    }

    private void Update()
    {
        m_slider.value = m_videoPlayer.frame;
    }

    #endregion

    #region BUTTONS_INPUTS

    public void PlayOrPause()
    {
        if (m_videoPlayer.isPlaying)
        {
            m_imagePlayButton.sprite = m_playIcon;
            Pause();
        }
        else
        {
            m_imagePlayButton.sprite = m_pauseIcon;
            Play();
        }
    }


    public void InvokeBackPercentVideo(int percent)
    {
        BackPercentVideo(Convert.ToUInt64(percent));
    }

    public void ValueSliderChanged(float value)
    {
        if (value == m_videoPlayer.frame)
            return;

        else
            m_videoPlayer.frame = Convert.ToInt64(value);
    }

    #endregion

    #region CONTROLLER_METHODES

    private void Play()
    {
        StartCoroutine(PlayVideo());
    }

    private void Pause()
    {
        if (!m_videoPlayer.isPlaying)
            return;

        m_videoPlayer.Pause();
        m_audioSource.Pause();
    }

    private void BackPercentVideo(ulong percent)
    {
        ulong totalFrame = m_videoPlayer.frameCount;
        ulong actualFrame = Convert.ToUInt64(m_videoPlayer.frame);

        if (actualFrame < MathUtils.PercentValueFromAnotherValue(percent, totalFrame))
            return;
        
        ulong actualPercent = MathUtils.PercentValueFromAnotherValue(actualFrame, totalFrame);
        m_videoPlayer.frame = Convert.ToInt64(MathUtils.PercentValue( actualPercent - percent, totalFrame));
    }
	
	IEnumerator PlayVideo()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!m_videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        m_rawImage.texture = m_videoPlayer.texture;
        m_videoPlayer.Play();
        m_audioSource.Play();
    }

    IEnumerator PrepareVideo()
    {
        m_videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!m_videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        m_slider.maxValue = m_videoPlayer.frameCount;
    }

    #endregion
}
