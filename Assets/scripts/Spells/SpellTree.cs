using UnityEngine;

[CreateAssetMenu(fileName = "New spelltree", menuName = "Spells/Spell Tree")]
public class SpellTree : ScriptableObject {

    public string m_name;
    public string m_description;

    public SpellLink[] m_spellLinks;
	
}
