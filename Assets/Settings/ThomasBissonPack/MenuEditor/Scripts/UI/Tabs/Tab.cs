using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tab : MonoBehaviour {

    [HideInInspector]
    public GameObject m_content;
    [HideInInspector]
    public Button m_button;
    [HideInInspector]
    public Image m_image;

    // Use this for initialization
    void Start () {
        m_image = GetComponent<Image>();
        m_button = GetComponent<Button>();
        m_content = transform.GetChild(1).gameObject;
	}
	
}
