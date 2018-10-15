using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BatController : MonoBehaviour {

    public enum MonsterState {
        HEALTHY,
        STUNNED,
        DEAD
    }

    //Stats
    [Header("Stats")]
    public int m_health;
    public int m_mana;
    public int m_FireIntel;
    public int m_EarthStrenght;
    public int m_WindAgility;
    public int m_WaterLuck;
    private int m_actualHealth;
    private int m_actualMana;


    //State
    private MonsterState m_state;

    //Animation
    private Animator m_animator;
    private int m_dieHash = Animator.StringToHash("die");
    private int m_attackHash = Animator.StringToHash("attack");

    //Character movement
    [Header("Movements")]
    public int m_speed = 15;
    public int m_rotation = 120;
    private CharacterController m_controller;
    private Vector3 m_moveDirection = Vector3.zero;
    private float m_gravity = -9.81f;
    private Vector3 m_velocity;
    private bool m_isGrounded = true;
    private Transform m_groundChecker;

    //Spells
    [Header("Spells")]
    public SpellTree m_basicSpellTree;
    public GameObject m_go_spell_cast_point;

    //UI
    [Header("UI")]
    private Slider m_healthSlider;
    private Slider m_manaSlider;

    // Use this for initialization
    void Start () {
        m_animator = GetComponent<Animator>();
        m_controller = GetComponent<CharacterController>();
        m_groundChecker = transform.GetChild(0);

        m_healthSlider = GameObject.Find("HealthSlider").GetComponent<Slider>();
        m_healthSlider.maxValue = m_health;
        m_healthSlider.value = m_health;
        m_actualHealth = m_health;

        m_manaSlider = GameObject.Find("ManaSlider").GetComponent<Slider>();
        m_manaSlider.maxValue = m_mana;
        m_manaSlider.value = m_mana;
        m_actualMana = m_mana;

        m_state = MonsterState.HEALTHY;
    }

    // Update is called once per frame
    void Update() {

        if(m_state == MonsterState.HEALTHY)
        {
            if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
            {
                m_moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
                m_moveDirection = transform.TransformDirection(m_moveDirection);
                m_controller.Move(m_speed * m_moveDirection * Time.deltaTime);
                transform.Rotate(0, Input.GetAxis("Horizontal") * m_rotation * Time.deltaTime, 0);
                m_animator.SetBool("mooving", true);
            }
            else
            {
                m_animator.SetBool("mooving", false);
            }

            m_isGrounded = Physics.CheckSphere(m_groundChecker.position, 0.02f, 1, QueryTriggerInteraction.Ignore);
            if (m_isGrounded && m_velocity.y < 0)
                m_velocity.y = 0f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_animator.SetTrigger(m_dieHash);
                StartCoroutine(BeStunForXSeconds(1));
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                m_animator.SetTrigger(m_attackHash);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                m_animator.SetTrigger(m_attackHash);
                GameObject spell = Instantiate(m_basicSpellTree.m_spellLinks[1].m_spell.m_prefab, m_go_spell_cast_point.transform.position, transform.rotation);
                m_actualMana -= m_basicSpellTree.m_spellLinks[1].m_spell.m_manaConsuption;
                //@TODO : make an observer to make the slider move
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                m_animator.SetTrigger(m_attackHash);
                GameObject spell = Instantiate(m_basicSpellTree.m_spellLinks[0].m_spell.m_prefab, m_go_spell_cast_point.transform.position, transform.rotation);
                FireBallController fireBallController = spell.GetComponent<FireBallController>();
                spell.GetComponent<Rigidbody>().AddForce(transform.forward * fireBallController.speed);
                Destroy(spell, fireBallController.time_alive);
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                m_animator.SetTrigger(m_attackHash);
                Instantiate(m_basicSpellTree.m_spellLinks[2].m_spell.m_prefab, m_go_spell_cast_point.transform.position, transform.rotation);
            }
        }
    }

    IEnumerator BeStunForXSeconds(float seconds)
    {
        m_state = MonsterState.STUNNED;
        yield return new WaitForSeconds(seconds);
        m_state = MonsterState.HEALTHY;
    }
}
