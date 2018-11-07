using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabController : MonoBehaviour {

    public Tab[] m_tabs;

	// Use this for initialization
	void Start () {
		foreach(Tab tab in m_tabs)
        {
            tab.m_button.onClick.AddListener(delegate
            {
                HideAllPanel();
                DisplayPanel(tab);
            });
        }
        HideAllPanel();
        DisplayPanel(m_tabs[0]);
	}

    private void DisplayPanel(Tab tab)
    {
        tab.m_content.SetActive(true);
        var tempColor = tab.m_image.color;
        tempColor.a = 1f;
        tab.m_image.color = tempColor;
    }


    private void HideAllPanel()
    {
        foreach (Tab tab in m_tabs)
        {
            tab.m_content.SetActive(false);
            var tempColor = tab.m_image.color;
            tempColor.a = .5f;
            tab.m_image.color = tempColor;
        }
    }


	
}
