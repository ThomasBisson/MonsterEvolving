using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour {


    //Stats
    [Header("Stats")]
    [SerializeField]
    private int m_health;
    [SerializeField]
    private int m_currentHealth;
    [SerializeField]
    private int m_mana;
    [SerializeField]
    private int m_currentMana;
    [SerializeField]
    private int m_FireIntel;
    [SerializeField]
    private int m_EarthStrenght;
    [SerializeField]
    private int m_WindAgility;
    [SerializeField]
    private int m_WaterLuck;

    private int m_actualHealth;
    private int m_actualMana;
    private int m_level;
    private int m_xpNeeded;
    private int m_currentXP;

    //UI
    private HUDUIManager m_HUDUIManager;


    //UI
    //[Header("UI")]
    //public Slider m_healthSlider;
    //public Slider m_manaSlider;

    // Use this for initialization
    void Start () {
        m_HUDUIManager = HUDUIManager.Instance;
        m_HUDUIManager.SetHealthObserver(delegate
        {
            return m_actualHealth;
        });
        ////m_healthSlider = GameObject.Find("HealthSlider").GetComponent<Slider>();
        //m_healthSlider.maxValue = m_health;
        //m_healthSlider.value = m_health;
        //m_actualHealth = m_health;

        ////m_manaSlider = GameObject.Find("ManaSlider").GetComponent<Slider>();
        //m_manaSlider.maxValue = m_mana;
        //m_manaSlider.value = m_mana;
        //m_actualMana = m_mana;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            m_actualHealth -= 10;
            m_HUDUIManager.RefreshHealthSlider();
        }
    }

    //public void TakeDamage()
}
