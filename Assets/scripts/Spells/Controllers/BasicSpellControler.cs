using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSpellControler : MonoBehaviour {

    [Header("Basic information")]
    public GameObject m_objectToDestroy;
    [SerializeField]
    protected float m_timeAlive;
    [SerializeField]
    protected Spell m_spell;

    protected CharacterStats m_statsSpellCaster;

	// Use this for initialization
	public virtual void Start () {
        if (m_objectToDestroy == null)
            Destroy(gameObject, m_timeAlive);
        else
            Destroy(m_objectToDestroy, m_timeAlive);
    }
	
	public void SetSpellCaster(CharacterStats stats)
    {
        m_statsSpellCaster = stats;
    }

    public void KillMonster(int givingXP)
    {
        m_statsSpellCaster.GainExperience(givingXP);
    }
}
