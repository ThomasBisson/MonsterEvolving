using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour {

    public int speed = 1000;
    public int mana_cost = 10;
    public int damage = 10;
    public int time_alive = 2;

    private AudioSource audio;

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
	}

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        if (audio != null)
            audio.Play(); //02 35 65 94 69  // antony g 
        else
            Debug.Log("ca marche pas trop");
    }
}
