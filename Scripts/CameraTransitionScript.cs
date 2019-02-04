//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: CameraTransitionScript.cs    						  /\\
//\  																  /\\
//\  Author  : Peter Phillips										  /\\
//\     															  /\\
//\  Date    : First entry - 06 / 01 / 2018							  /\\
//\     	   Last entry  - 08 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   : Script for smoothly rotating the camera and following  /\\
//\            the player around with the camera.                     /\\
//\                                                                   /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransitionScript : MonoBehaviour
{
    public GameObject player;
    public GameObject playerRotation;
    public bool bWasEPressed;
    public GameObject endLevel;

    private Vector3 vAngles;
    
    void Start ()
    {
        // Initialise the camera rotation vector at 0,0,0.
        vAngles = new Vector3(0.0f, 0.0f, 0.0f);
        // Arbitrary initialisation.
        bWasEPressed = false;
	}
	
	void Update ()
    {
        // Player input controls rotate 90° instantly when Q or E are pressed, camera follows the player rotation by reducing the difference in rotation by 10% each update leading to a smooth transition.
        // Some catches have been put in place to stop the camera rotating 270° anticlockwise instead of 90° clockwise when the rotation wraps around from 360° to 0° and vice versa.
        if (bWasEPressed)
        {
            if (playerRotation.transform.eulerAngles.y == 0.0f && transform.eulerAngles.y >= 180.0f)
            {
                vAngles.y += (360.0f - transform.eulerAngles.y) / 10.0f;
            }
            else if (playerRotation.transform.eulerAngles.y == 90.0f && transform.eulerAngles.y >= 270.0f)
            {
                vAngles.y += (450.0f - transform.eulerAngles.y) / 10.0f;
            }
            else
            {
                vAngles.y += (playerRotation.transform.eulerAngles.y - transform.eulerAngles.y) / 10.0f;
            }
        }
        else if (!bWasEPressed)
        {
            if (playerRotation.transform.eulerAngles.y == 270.0f && transform.eulerAngles.y <= 90.0f)
            {
                vAngles.y += (-90.0f - transform.eulerAngles.y) / 10.0f;
            }            
            else
            {
                vAngles.y += (playerRotation.transform.eulerAngles.y - transform.eulerAngles.y) / 10.0f;
            }
        }
    }

    private void LateUpdate()
    {
        if (!endLevel.GetComponent<EndScript>().bLevelComplete)
        {
            // The parent object of the camera matches the player position and its rotation matches the vector that smoothly tracks the player direction so long as the level isn't complete.
            transform.position = player.transform.position;
            transform.eulerAngles = vAngles;
        }        
    }
}
