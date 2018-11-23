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

public class CharacterStats : Stats {

    [Header("Elements stats")]
    [SerializeField]
    private int m_FireIntel;
    [SerializeField]
    private int m_EarthStrenght;
    [SerializeField]
    private int m_WindAgility;
    [SerializeField]
    private int m_WaterLuck;

    private int m_xpNeeded;
    private int m_currentXP;

    private float m_time;

    //UI
    private HUDUIManager m_HUDUIManager;

    #region UNITY_METHODES
    // Use this for initialization
    public override void Start () {
        base.Start();

        for (int i = 1; i < 100; i++)
        {
            print("[" + i + "] " + ExperienceHelper.GiveMeTheNextExperienceNeededToReachTheNextLevel(i));
        }

        m_xpNeeded = ExperienceHelper.STARTING_EXP_CHARACTER;
        m_currentXP = 0;

        //SET OBSERVERS
        Invoke("SetObservers", 1);

        //SET STATE
        m_state = MonsterState.HEALTHY;

        m_time = Time.time;
    }

    void Update()
    {
        if (m_HUDUIManager != null)
        {
            base.RegenManaLoop();
        }
    }

    #endregion

    #region HERITED_METHODES

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        m_HUDUIManager.RefreshHealthSlider();
    }

    public override bool UseMana(int manaUsed)
    {
        bool couldUseMana = base.UseMana(manaUsed);
        m_HUDUIManager.RefreshManaSlider();
        return couldUseMana;
    }

    public override void RegenMana(int manaRecup)
    {
        base.RegenMana(manaRecup);
        m_HUDUIManager.RefreshManaSlider();
    }

    #endregion


    public void GainExperience(int xp)
    {
        if(m_currentXP + xp >= m_xpNeeded)
        {
            int xpNextLevel = xp - (m_xpNeeded - m_currentXP);
            m_level++;
            m_xpNeeded = ExperienceHelper.GiveMeTheNextExperienceNeededToReachTheNextLevel(m_level);
            m_currentXP = xpNextLevel;
        }
        else
        {
            m_currentXP += xp;
        }
    }
    
    private void SetObservers()
    {
        //SET HUD SLIDERS
        m_HUDUIManager = HUDUIManager.Instance;
        m_HUDUIManager.SetHealthObserver(delegate
        {
            return m_currentHealth;
        }, m_health);

        m_HUDUIManager.SetManaObserver(delegate
        {
            return m_currentMana;
        }, m_mana);
    }


}
