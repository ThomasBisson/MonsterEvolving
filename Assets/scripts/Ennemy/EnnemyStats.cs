using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnnemyState
{
    HEALTHY,
    STUNNED,
    DEAD
}

public class EnnemyStats : MonoBehaviour {

    public int m_health;
    public int m_level;
    public int m_levelInterval;

    public int m_currentHealth;

    [HideInInspector]
    public EnnemyState m_ennemyState = EnnemyState.HEALTHY;

    // Use this for initialization
    void Start () {

        m_currentHealth = m_health;
	}
	
	public void TakeDamage(int damage)
    {
        if(m_currentHealth - damage < 0)
        {
            m_currentHealth = 0;
            m_ennemyState = EnnemyState.DEAD;
        }
    }
}
