using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public enum EnnemyState
//{
//    HEALTHY,
//    STUNNED,
//    DEAD
//}

public class EnnemyStats : Stats {

    [Header("Monster specifications")]
    [Range(-10f, 10f)]
    [SerializeField]
    private int m_levelInterval;


    [Header("HUD")]
    [SerializeField]
    private Image m_imageSliderHealth;

    [SerializeField]
    private Image m_imageSliderMana;

    #region UNITY_METHODES

    // Use this for initialization
    public override void Start () {
        base.Start();

        m_imageSliderHealth.fillAmount = 1;
	}

    #endregion

    #region HERITED_METHODES

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        m_imageSliderHealth.fillAmount = ConvertCurrentHealthToPercent();
    }

    public override bool UseMana(int manaUsed)
    {
        bool hadEnoughtMana = base.UseMana(manaUsed);
        m_imageSliderMana.fillAmount = ConvertCurrentManaToPercent();
        return hadEnoughtMana;
    }

    #endregion

    private float ConvertCurrentHealthToPercent()
    {
        return (MathUtils.PercentValueFromAnotherValue((float)m_currentHealth, (float)m_health) / 100f);
    }

    private float ConvertCurrentManaToPercent()
    {
        return (MathUtils.PercentValueFromAnotherValue((float)m_currentMana, (float)m_mana) / 100f);
    }
}
