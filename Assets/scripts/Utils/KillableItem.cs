using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KillableItem : MonoBehaviour {

    private Vector3 m_InitialPosition;

    private Quaternion m_InitialRotation;

    [SerializeField]
    private bool m_TpBackOnKillZone = true;
    [SerializeField]
    private bool m_InstaKillOnKillZone = false;

    [SerializeField]
    private UnityEvent m_OnKillZone;

    void Awake()
    {
        m_InitialPosition = transform.position;
        m_InitialRotation = transform.rotation;
    }

	public void Kill()
    {
        m_OnKillZone.Invoke();

        if (m_TpBackOnKillZone)
        {
            transform.position = m_InitialPosition;
            transform.rotation = m_InitialRotation;

            Rigidbody rigBod = GetComponent<Rigidbody>();
            if(rigBod != null)
            {
                rigBod.velocity = Vector3.zero;
            }
        }

        if (m_InstaKillOnKillZone)
        {
            Destroy(gameObject);
        }
    }
}
