using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    protected EnnemyStats m_ennemyStats;

    // Cible de l'ennemi
    protected Transform m_target;

    // Use this for initialization
    public virtual void Start()
    {
        m_ennemyStats = GetComponent<EnnemyStats>();
        m_target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public virtual bool ApplyDammage(int damage) { return false; }
}
