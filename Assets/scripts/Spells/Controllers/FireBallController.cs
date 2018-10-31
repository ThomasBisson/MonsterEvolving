using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour {

    public Spell m_spell;

    public int m_speed = 1000;

    ParticleSystem m_particleSystem;

	// Use this for initialization
	void Start () {
        m_particleSystem = GetComponent<ParticleSystem>();
        GetComponent<Rigidbody>().AddForce(transform.forward * m_speed);
        Destroy(gameObject, m_particleSystem.main.duration);
    }

    void OnParticleCollision(Collision collision)
    {
        print(collision.gameObject.tag);
        if(collision.gameObject.tag != "Player")
            Destroy(gameObject);
        else if(collision.gameObject.tag == "Ennemy")
        {
            collision.gameObject.GetComponent<AI>().ApplyDammage(m_spell.m_damage);
        }

        //if (audio != null)
        //    audio.Play(); //02 35 65 94 69  // antony g 
        //else
        //    Debug.Log("ca marche pas trop");
    }
}
