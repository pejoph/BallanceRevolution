//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: KeyScript.cs     								      /\\
//\  																  /\\
//\  Author  : Peter Phillips										  /\\
//\     															  /\\
//\  Date    : First entry - 04 / 01 / 2018							  /\\
//\     	   Last entry  - 04 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   : Script for unlocking a door with a key as well as      /\\
//\            rotating the key before it's picked up.                /\\
//\                                                                   /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour 
{
    public GameObject DoorLock;
    public GameObject Particles;

    private Vector3 vRotation;    

	void Start ()
    {
        // Set an initial rotation for the key.
        vRotation = new Vector3(0.0f, 135.0f, 0.0f);
	}
	
	void Update ()
    {
        // Key rotates 360° every 2 seconds.
        vRotation.y += 180.0f * Time.deltaTime;
        transform.eulerAngles = vRotation;
	}

    private void OnTriggerEnter(Collider other)
    {
        // When the key is picked up, it is destroyed along the the door lock.
        Destroy(DoorLock);
        Destroy(gameObject);
        Destroy(Particles);
    }
}
