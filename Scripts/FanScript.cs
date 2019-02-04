//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: FanScript.cs		        						      /\\
//\  																  /\\
//\  Author  : Peter Phillips										  /\\
//\     															  /\\
//\  Date    : First entry - 05 / 01 / 2018							  /\\
//\     	   Last entry  - 05 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   : Script for rotating the blades of a fan.               /\\
//\                                                                   /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanScript : MonoBehaviour
{
    private Vector3 vRotation;
    
	void Start ()
    {
        // Initialise the rotation vector to 0,0,0.
        vRotation = new Vector3(0.0f, 0.0f, 0.0f);
	}
	
	void Update ()
    {
        // Update the rotation vector and rotate the fans by 360° per second about the y-axis.
        vRotation.y = Time.time * 360.0f;
        transform.eulerAngles = vRotation;
	}
}
