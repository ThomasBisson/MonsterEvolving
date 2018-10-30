using System.Collections;
using UnityEngine;
using DG.Tweening;

public class PushButton : MonoBehaviour {

    public float m_scaleValue;

    private bool m_isOver;

	// Use this for initialization
	void Start () {
        m_isOver = true;
	}
	
	public void OnCollisionEnter(Collision col)
    {
        
        if(col.gameObject.tag == "Hand")
            if (m_isOver)
                StartCoroutine(WaitXSeconds(1));
    }

    IEnumerator WaitXSeconds(float seconds)
    {
        print("ICICICICICICICICICICICIC");
        m_isOver = false;
        transform.DOScaleZ(transform.localScale.z - m_scaleValue, .5f).SetEase(Ease.Linear).OnComplete(delegate
        {
            transform.DOScaleZ(transform.localScale.z + m_scaleValue, .5f).SetEase(Ease.Linear);
        });
        yield return new WaitForSeconds(seconds);
        m_isOver = true;
    }
}
