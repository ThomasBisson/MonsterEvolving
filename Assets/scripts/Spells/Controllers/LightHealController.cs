using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHealController : BasicSpellControler {

	// Use this for initialization
	public override void Start () {
        base.Start();
        m_statsSpellCaster.RegenHealth(m_spell.m_heal);
	}
	
}
