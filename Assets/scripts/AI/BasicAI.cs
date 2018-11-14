using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BasicAI : AI
{
    //Distance entre le joueur et l'ennemi
    private float Distance;

    //Distance de poursuite
    public float chaseRange = 10;

    private float attackTime;

    // Agent de navigation
    private UnityEngine.AI.NavMeshAgent agent;

    // Animations de l'ennemi
    private Animator animator;

    // Use this for initialization
    public override void Start()
    {
        base.Start();

        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = gameObject.GetComponent<Animator>();
        attackTime = Time.time;
    }

    void Update()
    {
        if (m_ennemyStats.m_state != MonsterState.DEAD)
        {
            // On calcule la distance entre le joueur et l'ennemi, en fonction de cette distance on effectue diverses actions
            Distance = Vector3.Distance(m_target.position, transform.position);

            // Quand l'ennemi est loin = idle
            if (Distance > chaseRange)
            {
            }

            // Quand l'ennemi est proche mais pas assez pour attaquer
            if (Distance < chaseRange && Distance > m_ennemyStats.m_basicAttackRange)
            {
                //transform.LookAt(Target.position);
                animator.SetBool("Moving", true);
                agent.destination = m_target.position;
            }
            else
            {
                if (transform.position == agent.destination)
                    animator.SetBool("Moving", false);
            }

            //Quand l'ennemi est assez proche pour attaquer
            if (Distance < m_ennemyStats.m_basicAttackRange)
            {
                attack();
            }
        }
        else
        {
            agent.isStopped = true;
            animator.SetBool("Moving", false);
        }
    }

    // Combat
    void attack()
    {
        // empeche l'ennemi de traverser le joueur
        agent.destination = transform.position;

        //Si pas de cooldown
        if (Time.time > attackTime)
        {
            animator.SetTrigger("Attack1Trigger");
            m_target.gameObject.GetComponent<Stats>().TakeDamage(m_ennemyStats.m_basicAttackDamage);
            attackTime = Time.time + m_ennemyStats.m_basicAttackCooldown;
        }
    }
}