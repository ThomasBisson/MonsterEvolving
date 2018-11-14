using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour {

    public Spell m_spell;

    public int m_speed = 1000;

    ParticleSystem m_particleSystem;

    Rigidbody m_rigidbody;

	// Use this for initialization
	void Start () {
        m_particleSystem = GetComponent<ParticleSystem>();
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.AddForce(transform.forward * m_speed);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            m_rigidbody.velocity = Vector3.zero;
            m_rigidbody.angularVelocity = Vector3.zero;
            Destroy(gameObject, .1f);
        }

        if (collision.gameObject.tag == "Ennemy")
        {
            collision.gameObject.GetComponent<EnnemyStats>().TakeDamage(m_spell.m_damage);
        }
    }
}
