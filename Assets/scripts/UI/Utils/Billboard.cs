using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {

    private Transform _camera;

    void Start()
    {
        _camera = Camera.main.transform;
    }

	// Update is called once per frame
	void Update () {
        Quaternion newRot = Quaternion.LookRotation(transform.position - _camera.position, Vector3.up);
        newRot.z = 0;
        newRot.x = 0;
        transform.rotation = newRot;
    }
}
