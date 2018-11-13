using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EnnemyState
{
    HEALTHY,
    STUNNED,
    DEAD
}

public class EnnemyStats : Stats {

    [SerializeField]
    private int m_health;
    [SerializeField]
    private int m_level;
    [SerializeField]
    private int m_levelInterval;
    [SerializeField]
    private int m_basicAttackDamage = 10;
    [SerializeField]
    private int m_basicAttackCooldown = 1;
    [SerializeField]
    private float m_basicAttackRange = 2.2f;

    private int m_currentHealth;

    [SerializeField]
    private Image m_imageSlider;

    [HideInInspector]
    public EnnemyState m_ennemyState = EnnemyState.HEALTHY;

    // Use this for initialization
    void Start () {
        m_currentHealth = m_health;
        //m_imageSlider = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        m_imageSlider.fillAmount = 1;
	}
	
	public void TakeDamage(int damage)
    {
        if(m_currentHealth - damage < 0)
        {
            m_currentHealth = 0;
            m_ennemyState = EnnemyState.DEAD;
        } else
        {
            m_currentHealth -= damage;
        }
        print(ConvertCurrentHealthToPercent() + " " + m_currentHealth);
        m_imageSlider.fillAmount = ConvertCurrentHealthToPercent();
    }

    public void ApplyDamage(CharacterStats character, int damage = 0)
    {
        if (damage == 0)
            damage = m_basicAttackDamage;
        character.TakeDamage(damage);
    }

    private float ConvertCurrentHealthToPercent()
    {
        return (MathUtils.PercentValueFromAnotherValue(m_currentHealth, m_health) / 100);// (((float)m_currentHealth * 100f) /(float)m_health) / 100f;
    }
}
