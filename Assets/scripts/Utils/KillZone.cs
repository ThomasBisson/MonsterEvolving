using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour {

	private void OnTriggerEnter(Collider other)
    {
        KillableItem item = other.GetComponent<KillableItem>();

        if (item != null)
            item.Kill();
    }
}
