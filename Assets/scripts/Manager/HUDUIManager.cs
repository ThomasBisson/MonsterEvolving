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
	}

    public void SetHealthObserver(HUDObserverValueGetter observer, float health)
    {
        m_healthSlider.SetMaxValueSlider(health);
        m_healthSlider.m_observer = observer;
    }

    public void RefreshHealthSlider()
    {
        m_healthSlider.UpdateMyValue();
    }

    public void SetManaObserver(HUDObserverValueGetter observer, float mana)
    {
        m_manaSlider.SetMaxValueSlider(mana);
        m_manaSlider.m_observer = observer;
    }

    public void RefreshManaSlider()
    {
        m_manaSlider.UpdateMyValue();
    }

}
