using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour {

    public float turnSpeed = 4.0f;
    public Transform player;

    private Vector3 offset;

    private Vector3 offsetPlayer;         //Private variable to store the offset distance between the player and camera

    void Start()
    {
        offset = transform.position - player.position; ; //new Vector3(player.position.x, player.position.y + 8.0f, player.position.z + 7.0f);
        offsetPlayer = transform.position - player.position;
        transform.LookAt(player.position);
    }

    void LateUpdate()
    {
        transform.position = player.position + offsetPlayer;
        

        if (Input.GetKey(KeyCode.Mouse0))
        {
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
            transform.position = player.position + offset;
            transform.LookAt(player.position);

            offsetPlayer = transform.position - player.position;
        }
        else if(Input.GetKey(KeyCode.Mouse1))
        {
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
            transform.position = player.position + offset;
            transform.LookAt(player.position);

            player.rotation = transform.rotation;

            offsetPlayer = transform.position - player.position;
        }
        else if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            transform.position += transform.forward * 0.5f;
            offsetPlayer = transform.position - player.position;
            offset = transform.position - player.position;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            transform.position -= transform.forward * 0.5f;
            offsetPlayer = transform.position - player.position;
            offset = transform.position - player.position;
        }
    }
}
