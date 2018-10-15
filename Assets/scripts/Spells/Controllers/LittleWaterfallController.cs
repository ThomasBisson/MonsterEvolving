using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleWaterfallController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.tag);
    }
}
