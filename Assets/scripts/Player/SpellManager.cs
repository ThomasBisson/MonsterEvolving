using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour {

    //Spells
    [Header("Spells")]
    public SpellTree m_basicSpellTree;
    public Transform m_go_spell_cast_point;

    // Use this for initialization
    void Start () {
		
	}
	
	public bool InstantiateSpell(CharacterStats characterStats, int idSpell)
    {
        if (characterStats.UseMana(m_basicSpellTree.m_spellLinks[idSpell].m_spell.m_manaConsuption))
        {
            if(LocationSpell.OnMonster == m_basicSpellTree.m_spellLinks[idSpell].m_spell.m_locationSpell)
            {
                Instantiate(m_basicSpellTree.m_spellLinks[idSpell].m_spell.m_prefab,
                transform.position,
                transform.rotation,
                transform);
            } else
            {
                Instantiate(m_basicSpellTree.m_spellLinks[idSpell].m_spell.m_prefab,
                LocationSpellToVector(m_basicSpellTree.m_spellLinks[idSpell].m_spell.m_locationSpell),
                transform.rotation);
            }
            return true;
        }
        return false;
    }

    private Vector3 LocationSpellToVector(LocationSpell locationSpell)
    {
        switch (locationSpell)
        {
            case LocationSpell.OnSpellPoint:
                return m_go_spell_cast_point.position;
            default:
                return Vector3.zero;
        }
    }
}
