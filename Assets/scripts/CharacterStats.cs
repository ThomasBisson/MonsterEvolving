using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour {


    //Stats
    [Header("Stats")]
    public int m_health;
    public int m_currentHealth;
    public int m_mana;
    public int m_currentMana;
    public int m_FireIntel;
    public int m_EarthStrenght;
    public int m_WindAgility;
    public int m_WaterLuck;

    [HideInInspector]
    public int m_actualHealth;
    [HideInInspector]
    public int m_actualMana;
    [HideInInspector]
    public int m_level;
    [HideInInspector]
    public int m_xpNeeded;
    [HideInInspector]
    public int m_cuurentXP;


    //UI
    [Header("UI")]
    private Slider m_healthSlider;
    private Slider m_manaSlider;

    // Use this for initialization
    void Start () {
        m_healthSlider = GameObject.Find("HealthSlider").GetComponent<Slider>();
        m_healthSlider.maxValue = m_health;
        m_healthSlider.value = m_health;
        m_actualHealth = m_health;

        m_manaSlider = GameObject.Find("ManaSlider").GetComponent<Slider>();
        m_manaSlider.maxValue = m_mana;
        m_manaSlider.value = m_mana;
        m_actualMana = m_mana;
    }
}
