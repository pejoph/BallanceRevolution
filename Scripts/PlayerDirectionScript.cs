//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: PlayerDirectionScript							      /\\
//\  																  /\\
//\  Author  : Peter Phillips										  /\\
//\     															  /\\
//\  Date    : First entry - 06 / 01 / 2018							  /\\
//\     	   Last entry  - 08 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   : Script for turning the player direction used in        /\\
//\            turning the camera and rotating the user controls      /\\
//\            and the arrows.                                        /\\
//\                                                                   /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirectionScript : MonoBehaviour
{
    public GameObject player;
    public GameObject gameCam;
    private CameraTransitionScript cameraTransitionScript;
    
	void Start ()
    {
        // Get the CameraTransitionScript attached to the gameCam object.
        cameraTransitionScript = gameCam.GetComponent<CameraTransitionScript>();
	}

	void Update ()
    {
        // Rotate attached object by 90° when Q (anti-clockwise) or E (clockwise) are pressed.
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(transform.up, 90.0f);
            cameraTransitionScript.bWasEPressed = true;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(transform.up, -90.0f);
            cameraTransitionScript.bWasEPressed = false;
        }
    }
    private void LateUpdate()
    {
        // Stay on the player's position.
        transform.position = player.transform.position;
    }
}
