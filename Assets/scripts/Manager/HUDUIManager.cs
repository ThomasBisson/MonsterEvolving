using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate int HUDObserverValueGetter();

public class HUDUIManager : MonoBehaviour {

    public static HUDUIManager Instance;

    [SerializeField]
    private SliderUpdate m_healthSlider;
    [SerializeField]
    private SliderUpdate m_manaSlider;
    [SerializeField]
    private SliderUpdate m_expSlider;

    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
        //ValueGetter value = 

	}

    public void SetHealthObserver(HUDObserverValueGetter observer)
    {
        m_healthSlider.m_observer = observer;
        //m_healthSlider.maxValue = m_health;
        //m_healthSlider.value = m_health;
        //m_actualHealth = m_health;
    }

    public void RefreshHealthSlider()
    {
        m_healthSlider.UpdateMyValue();
    }

}
