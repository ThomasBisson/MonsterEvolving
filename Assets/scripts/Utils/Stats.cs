using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

    /****** BASIC STATS ******/
    [Header("Basic stats")]
    [SerializeField]
	protected int m_health;
    protected int m_currentHealth;
    [SerializeField]
    protected int m_mana;
    protected int m_currentMana;
    [SerializeField]
    protected int m_regenManaSecondPercent;
    protected float m_timeRegenMana;

    /****** Peticular Stats ******/
    [Header("Peticular Stats")]
    [SerializeField]
    protected int m_level;
    public int m_baseXPGiving = 0;

    /****** Basic attack ******/
    [Header("Basic attack")]
    [SerializeField]
    public int m_basicAttackDamage;
    [SerializeField]
    public float m_basicAttackCooldown;
    [SerializeField]
    public float m_basicAttackRange;

    /****** Actual state ******/
    [Header("Starting state")]
    public MonsterState m_state;

    public virtual void Start()
    {
        m_currentHealth = m_health;
        m_currentMana = m_mana;
        m_timeRegenMana = Time.time;
    }

    public bool isDead() { return m_state == MonsterState.DEAD; }

    public virtual void RegenHealth(int health)
    {
        if (m_currentHealth + health > m_health)
            m_currentHealth = m_health;
        else
            m_currentHealth += health;
    }

    public virtual void RegenManaLoop()
    {
        if (m_timeRegenMana + 1 < Time.time)
        {
            m_timeRegenMana = Time.time;
            RegenMana((m_regenManaSecondPercent * m_mana) / 100);
        }
    }

    public virtual void TakeDamage(int damage)
    {
        m_currentHealth -= damage;
        if (m_currentHealth <= 0)
        {
            m_currentHealth = 0;
            m_state = MonsterState.DEAD;
        }
    }

    public virtual void ApplyBasicAttackDamage(Stats stats, int damage)
    {
        stats.TakeDamage(damage);
    }

    public virtual bool UseMana(int manaUsed)
    {
        if (m_currentMana < manaUsed)
            return false;

        m_currentMana -= manaUsed;
        if (m_currentMana < 0)
            m_currentMana = 0;
        return true;
    }

    public virtual void RegenMana(int manaRecup)
    {
        if (manaRecup + m_currentMana > m_mana)
            m_currentMana = m_mana;
        else
            m_currentMana += manaRecup;
    }
}
