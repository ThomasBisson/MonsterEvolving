using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//STATE
public enum MonsterState
{
    HEALTHY,
    STUNNED,
    DEAD
}

public class CharacterStats : MonoBehaviour {

    [HideInInspector]
    public MonsterState m_state;

    //Stats
    [Header("Stats")]
    [SerializeField]
    private int m_health;
    [SerializeField]
    private int m_mana;
    [SerializeField]
    private int m_FireIntel;
    [SerializeField]
    private int m_EarthStrenght;
    [SerializeField]
    private int m_WindAgility;
    [SerializeField]
    private int m_WaterLuck;

    private int m_currentHealth;
    private int m_currentMana;
    private int m_level;
    private int m_xpNeeded;
    private int m_currentXP;

    //UI
    private HUDUIManager m_HUDUIManager;

    #region UNITY_METHOD
    // Use this for initialization
    void Start () {
        //SET OBSERVERS
        Invoke("SetObservers", 1);

        //SET STATE
        m_state = MonsterState.HEALTHY;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            TakeDamage(10);
        }
    }

    #endregion

    private void SetObservers()
    {
        //SET HUD SLIDERS
        m_HUDUIManager = HUDUIManager.Instance;
        m_currentHealth = m_health;
        m_HUDUIManager.SetHealthObserver(delegate
        {
            return m_currentHealth;
        }, m_health);

        m_currentMana = m_mana;
        m_HUDUIManager.SetManaObserver(delegate
        {
            return m_currentMana;
        }, m_mana);
    }

    public void TakeDamage(int damage)
    {
        print(m_currentHealth);
        m_currentHealth -= damage;
        if(m_currentHealth <= 0)
        {
            print("Dead");
            m_currentHealth = 0;
            m_state = MonsterState.DEAD;
        }
        m_HUDUIManager.RefreshHealthSlider();
    }

    public bool UseMana(int manaUsed)
    {
        if (m_currentMana < manaUsed)
            return false;

        m_currentMana -= manaUsed;
        if (m_currentMana < 0)
            m_currentMana = 0;
        m_HUDUIManager.RefreshManaSlider();
        return true;
    }
}
