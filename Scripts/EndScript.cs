//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: EndScript.cs    			        		        	  /\\
//\  																  /\\
//\  Author  : Peter Phillips										  /\\
//\     															  /\\
//\  Date    : First entry - 09 / 01 / 2018							  /\\
//\     	   Last entry  - 09 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   : Script for moving the gazebo and player once the       /\\
//\            level is complete                                      /\\
//\                                                                   /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    public GameObject joint;
    public GameObject player;
    public bool bLevelComplete;

    private Vector3 vMovement;
    private float fTimer;
    
	void Start ()
    {
        // Store the gazebo position in a vector.
        vMovement = transform.position;
        // State that the level is not complete.
        bLevelComplete = false;
        // Initialise the movement timer to 0.
        fTimer = 0.0f;
	}

    private void FixedUpdate()
    {
        if (bLevelComplete && fTimer < 20.0f)
        {
            // For 20 seconds after the level is complete, move both the gazebo and the player along in the z-direction.
            vMovement.z += Time.deltaTime;
            fTimer += Time.deltaTime;
            transform.position = vMovement;
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            // If the player reaches the end, destroy the joint the attaches the bridge to the gazebo, change the gazebo to 'not kinematic' (so it can move) and call the EndLevel() function (this brings up the end screen after 4 seconds).
            Destroy(joint.GetComponent<HingeJoint>());
            GetComponent<Rigidbody>().isKinematic = false;
            bLevelComplete = true;
            player.GetComponent<PlayerScript>().EndLevel();
        }
    }
}
