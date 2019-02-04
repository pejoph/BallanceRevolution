//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: TeleporterScript.cs								      /\\
//\  																  /\\
//\  Author  : Peter Phillips										  /\\
//\     															  /\\
//\  Date    : First entry - 04 / 01 / 2018							  /\\
//\     	   Last entry  - 07 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   : Script for animating teleportation orbs and            /\\
//\            teleporting player (or any rigidbody) to destination   /\\
//\            orb.                                                   /\\
//\                                                                   /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterScript : MonoBehaviour
{
    public GameObject Destination;

    private Vector3 vBobVector;
    private float fHeight;

	void Start ()
    {
        // Initialise bob position.
        vBobVector = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        // Initialise height to teleport player to.
        fHeight = transform.position.y;
    }
	
	void Update ()
    {
        // Transform the orb so that it displays simple harmonic motion.
        vBobVector.y = fHeight + .2f * Mathf.Sin((Time.time * Mathf.PI));
        transform.position = vBobVector;
	}

    private void OnTriggerEnter(Collider other)
    {
        // Teleports the player to the destination orb.
        other.transform.position = Destination.transform.position;
    }
}
