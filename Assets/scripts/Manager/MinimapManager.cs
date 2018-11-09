using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapManager : MonoBehaviour {

    public Transform m_target;
    public float m_yOffset;
    public float m_zoom;

	void LateUpdate () {
        Vector3 newPosition = m_target.position;
        newPosition.y = m_yOffset;
        transform.position = newPosition;
	}
}
