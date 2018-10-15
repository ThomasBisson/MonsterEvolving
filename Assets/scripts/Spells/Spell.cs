using UnityEngine;

[CreateAssetMenu(fileName = "New spell", menuName = "Spells/Spell")]
public class Spell : ScriptableObject {

    public GameObject m_prefab;
    public string m_name;
    public string m_description;
    public int m_damage;
    public int m_manaConsuption;
    public int m_levelAvailable;

    public Sprite m_image;
    
}
