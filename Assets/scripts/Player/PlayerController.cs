using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private CharacterStats m_characterStats;

    //Animation
    private Animator m_animator;
    private int m_dieHash = Animator.StringToHash("die");
    private int m_attackHash = Animator.StringToHash("attack");

    //Character movement
    [Header("Movements")]
    public int m_moveSpeed = 15;
    public int m_rotationSpeed = 120;
    public float m_JumpHeight = 150f;
    //public float m_groundDistance = 50f;
    //public LayerMask m_groundLayer;
    //public Transform m_groundChecker;

    private CharacterController m_controller;
    private float m_gravity = -9.81f;
    private Vector3 m_velocity;
    private bool m_isGrounded = true;

    //Character inputs
    [Header("Movements Inputs")]
    public KeyCode m_jumpKeyCode;

    //Spells
    private SpellManager m_spellManager;
    //SpellsInput
    [Header("Spell Inputs")]
    public KeyCode[] m_SpellKeyCode = new KeyCode[9];

    // Use this for initialization
    void Start () {
        m_animator = GetComponent<Animator>();
        m_controller = GetComponent<CharacterController>();
        m_characterStats = GetComponent<CharacterStats>();
        m_spellManager = GetComponent<SpellManager>();
    }

    // Update is called once per frame
    void Update() {

        if(m_characterStats.m_state == MonsterState.HEALTHY)
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

            //JUMP
            //m_isGrounded = Physics.CheckSphere(m_groundChecker.position, m_groundDistance, m_groundLayer, QueryTriggerInteraction.Ignore);

            m_isGrounded = m_controller.isGrounded;
            if (m_isGrounded && m_velocity.y < 0)
                m_velocity.y = 0f;

            if(Input.GetKeyDown(m_jumpKeyCode) && m_isGrounded)
            {
                m_velocity.y += m_JumpHeight * 2; //Mathf.Sqrt(m_JumpHeight  * m_gravity);
            }

            //RUN
            if (Input.GetAxis("Vertical") != 0)
            {
                Vector3 m_moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
                m_moveDirection = transform.TransformDirection(m_moveDirection);
                m_controller.Move(m_moveSpeed * m_moveDirection * Time.deltaTime);
                m_animator.SetBool("mooving", true);
            } else
            {
                m_animator.SetBool("mooving", false);
            }

            //ROTATE
            if (Input.GetAxis("Horizontal") != 0)
                transform.Rotate(0, Input.GetAxis("Horizontal") * m_rotationSpeed * Time.deltaTime, 0);

            m_velocity.y += m_gravity * Time.deltaTime;
            m_controller.Move(m_velocity * Time.deltaTime);

            //Basic attack
            //if (Input.GetKeyDown(KeyCode.Mouse1))
            //{
            //    m_animator.SetTrigger(m_attackHash);
            //}

            //SPELL
            for (int i = 0; i < m_SpellKeyCode.Length; i++)
            {
                if (Input.GetKeyDown(m_SpellKeyCode[i]))
                {
                    if(m_spellManager.InstantiateSpell(m_characterStats, i))
                        m_animator.SetTrigger(m_attackHash);
                }
            }

            } else if (m_characterStats.m_state == MonsterState.DEAD) {
            m_animator.SetTrigger(m_dieHash);
            //GAME OVER
        }
    }

    

    IEnumerator BeStunForXSeconds(float seconds)
    {
        m_characterStats.m_state = MonsterState.STUNNED;
        yield return new WaitForSeconds(seconds);
        m_characterStats.m_state = MonsterState.HEALTHY;
    }
}
