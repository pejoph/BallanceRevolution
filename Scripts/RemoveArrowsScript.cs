//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: RemoveArrowsScript.cs								  /\\
//\  																  /\\
//\  Author  : Peter Phillips										  /\\
//\     															  /\\
//\  Date    : First entry - 07 / 01 / 2017							  /\\
//\     	   Last entry  - 07 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   : Script for triggering the removal of the arrows once   /\\
//\            the player has left the starting area.                 /\\
//\                                                                   /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveArrowsScript : MonoBehaviour
{
    public GameObject arrows;

    private void OnTriggerEnter(Collider other)
    {
        // Sets the progress bool to true so the arrows start to fade away and ultimately disappear after 10 seconds.
        arrows.GetComponent<ArrowScript>().bProgress = true;
    }
}
