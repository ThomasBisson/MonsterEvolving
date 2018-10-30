using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GradientSlider : MonoBehaviour {

    [SerializeField]
    private Slider m_Slider;

    [SerializeField]
    private Image m_SliderFill;

    [SerializeField]
    private Color m_MinColor;

    [SerializeField]
    private Color m_MaxColor;

	// Update is called once per frame
	void Update () {
        m_SliderFill.color = Color.Lerp(m_MinColor, m_MaxColor, m_Slider.value);
	}
}
