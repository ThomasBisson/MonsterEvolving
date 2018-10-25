using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSpellControler : MonoBehaviour {

    public float m_timeAlive;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, m_timeAlive);
    }
	
	
}
