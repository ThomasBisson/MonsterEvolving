using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SoundWaveController : BasicSpellControler {
    
    [Header("Specific information")]
    [SerializeField]
    private Transform m_pivot;
    
	// Use this for initialization
	public override void Start () {
        base.Start();
        m_pivot.DOScaleZ(36f, 1.6f);
	}

    void OnTriggerEnter(Collider collider)
    {
        if(collider.transform.tag == "Ennemy")
        {
            EnnemyStats ennemy = collider.gameObject.GetComponent<EnnemyStats>();
            ennemy.TakeDamage(m_spell.m_damage);
            if (ennemy.isDead())
                KillMonster(ennemy.GetComponent<EnnemyStats>().m_baseXPGiving);
        }
    }

}
