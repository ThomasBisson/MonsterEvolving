using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    protected EnnemyStats m_ennemyStats;

    // Use this for initialization
    public virtual void Start()
    {
        m_ennemyStats = GetComponent<EnnemyStats>();
    }

    public virtual bool ApplyDammage(int damage) { return false; }
}
