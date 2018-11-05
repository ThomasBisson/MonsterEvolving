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

public class EnnemyStats : MonoBehaviour {

    [SerializeField]
    private int m_health;
    [SerializeField]
    private int m_level;
    [SerializeField]
    private int m_levelInterval;

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
    private float ConvertCurrentHealthToPercent()
    {
        return (((float)m_currentHealth * 100f) /(float)m_health) / 100f;
    }
}
