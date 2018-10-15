using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New spell link", menuName = "Spells/Spell Link")]
public class SpellLink : ScriptableObject {

    public Spell[] m_neededPreviousSpells;
    public Spell m_spell;

}
