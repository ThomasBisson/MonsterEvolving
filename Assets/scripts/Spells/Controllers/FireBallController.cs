using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour {

    public int m_speed = 1000;
    public int m_manaCost = 10;
    public int m_damage = 10;
    public int m_timeAlive = 2;

    private AudioSource audio;

	// Use this for initialization
	void Start () {
        //audio = GetComponent<AudioSource>();
        GetComponent<Rigidbody>().AddForce(transform.forward * m_speed);
        Destroy(spell, fireBallController.time_alive);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

        //if (audio != null)
        //    audio.Play(); //02 35 65 94 69  // antony g 
        //else
        //    Debug.Log("ca marche pas trop");
    }
}
