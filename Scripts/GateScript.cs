//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: GateScript.cs		    						      /\\
//\  																  /\\
//\  Author  : Peter Phillips										  /\\
//\     															  /\\
//\  Date    : First entry - 04 / 01 / 2018							  /\\
//\     	   Last entry  - 04 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   : Script for changing the material and collisions for    /\\
//\            a gate when it's opened.                               /\\
//\                                                                   /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    public Material mRed;
    public Material mGreen;
    public bool bIsOpen;

    private Renderer rMyRenderer;
    private Collider rMyCollider;
    private bool bCheck;
    
	void Start ()
    {
        // Get the renderer and collider components of the attached object.
        rMyRenderer = GetComponent<Renderer>();
        rMyCollider = GetComponent<Collider>();
        // State that the gate is closed and has not been opened.
        bIsOpen = false;
        bCheck = false;
	}
	
	void Update ()
    {
		if (bIsOpen && !bCheck)
        {
            // Change material to green.
            rMyRenderer.material = mGreen;
            // Turn off the collider so the gate can be passed.
            rMyCollider.enabled = false;
            // State that the gate has been opened so this part of the code isn't called every update.
            bCheck = true;
        }
	}
}
