using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUpdate : MonoBehaviour {

    private Slider m_slider;

    [HideInInspector]
    public HUDObserverValueGetter m_observer;

	// Use this for initialization
	void Start () {
        m_slider = GetComponent<Slider>();
        m_slider.maxValue = 100;
        m_slider.value = 100;
	}

    public void UpdateMyValue()
    {
        m_slider.value = m_observer();
    }

}
