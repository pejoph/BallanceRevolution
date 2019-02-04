//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: LiftScript.cs    								      /\\
//\  																  /\\
//\  Author  : Peter Phillips										  /\\
//\     															  /\\
//\  Date    : First entry - 06 / 01 / 2018							  /\\
//\     	   Last entry  - 06 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   : Script for lifting objects with the fan.               /\\
//\                                                                   /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftScript : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        // Forces any object in the collider upwards.
        other.GetComponent<Rigidbody>().AddForce(0.0f, 120.0f, 0.0f);        
    }
}
