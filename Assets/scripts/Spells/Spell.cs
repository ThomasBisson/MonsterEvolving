using UnityEngine;

public enum LocationSpell
{
    OnMonster,
    OnSpellPoint,
    OnCursor
}

[CreateAssetMenu(fileName = "New spell", menuName = "Spells/Spell")]
public class Spell : ScriptableObject {

    public GameObject m_prefab;
    public string m_name;
    public string m_description;
    public int m_damage;
    public int m_heal;
    public int m_manaConsuption;
    public int m_cooldown;
    public int m_levelAvailable;
    public LocationSpell m_locationSpell;

    public Sprite m_image;
    
}
