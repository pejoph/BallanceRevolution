//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: CheckpointScript.cs    			        			  /\\
//\  																  /\\
//\  Author  : Peter Phillips										  /\\
//\     															  /\\
//\  Date    : First entry - 08 / 01 / 2018							  /\\
//\     	   Last entry  - 08 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   : Script for displaying a message and animation upon     /\\
//\            reaching a checkpoint and setting the player's         /\\
//\            respawn position.                                      /\\
//\                                                                   /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public GameObject player;
    public GameObject fire1;
    public GameObject fire2;
    public float fTimer;

    private bool bHasReachedCheckpoint;
    
    void Start ()
    {
        // Stop the fire animation.
        fire1.GetComponent<ParticleSystem>().Stop();		
        fire2.GetComponent<ParticleSystem>().Stop();
        // Set the timer for displaying a message to 0.
        fTimer = 0.0f;
        // State that the player has not reached the checkpoint.
        bHasReachedCheckpoint = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!bHasReachedCheckpoint)
        {
            // Play the fire animation.
            fire1.GetComponent<ParticleSystem>().Play();
            fire2.GetComponent<ParticleSystem>().Play();
            // Set the timer to 4 so the checkpoint message displays for 4 seconds.
            fTimer = 4.0f;
            // Change the player's respawn position to this checkpoint.
            player.GetComponent<PlayerScript>().vRespawnPos = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
            // State that the player has reached the checkpoint so nothing happens if player moves onto the checkpoint again.
            bHasReachedCheckpoint = true;
        }
    }
}
