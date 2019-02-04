//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: CameraScript.cs										  /\\
//\  																  /\\
//\  Author  : Peter Phillips										  /\\
//\     															  /\\
//\  Date    : First entry - 22 / 12 / 2017							  /\\
//\     	   Last entry  - 08 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   : Script for focusing the camera on the player after     /\\
//\            the level is finished and zooming in and out using     /\\
//\            the scroll wheel.                                      /\\
//\                                                                   /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public GameObject endLevel;

    private void Start()
    {
        // Initialise FOV.
        GetComponent<Camera>().fieldOfView = 60.0f;
    }

    private void Update()
    {
        // Zooms the camera in and out with the scrollwheel by changing the field of view.
        // 7 total settings ranging from 30 to 90 with 60 being the default.
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && GetComponent<Camera>().fieldOfView > 30)
        {
            GetComponent<Camera>().fieldOfView -= 10;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0 && GetComponent<Camera>().fieldOfView < 90)
        {
            GetComponent<Camera>().fieldOfView += 10;
        }
    }

    private void LateUpdate()
    {
        // Once the level is complete, the camera looks at the player (and stays in the same position due to another script).
        if (endLevel.GetComponent<EndScript>().bLevelComplete)
        {
            transform.LookAt(player.transform.position);
        }
    }
}
