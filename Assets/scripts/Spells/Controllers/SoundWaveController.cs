using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SoundWaveController : MonoBehaviour {
    [SerializeField]
    private Spell m_spell;

    [SerializeField]
    private Transform m_pivot;
    
	// Use this for initialization
	void Start () {
        m_pivot.DOScaleZ(36f, 1.6f);
	}

    void OnTriggerEnter(Collider collider)
    {
        if(collider.transform.tag == "Ennemy")
        {
            collider.gameObject.GetComponent<EnnemyStats>().TakeDamage(m_spell.m_damage);
        }
    }

}
