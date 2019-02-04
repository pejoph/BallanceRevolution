//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: ButtonScript.cs										  /\\
//\  																  /\\
//\  Author  : Peter Phillips										  /\\
//\     															  /\\
//\  Date    : First entry - 03 / 01 / 2018							  /\\
//\     	   Last entry  - 04 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   : Script for changing the appearance of a button when    /\\
//\            pressed and switching a gate to 'open'.                /\\
//\                                                                   /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public Material mNotPressed;
    public Material mPressed;
    public GameObject gate;

    private Renderer rMyRenderer;
    private Vector3 vScale;
    private GateScript gateScript;
    
    void Start ()
    {
        // Get the attached object's renderer and set the material.
        rMyRenderer = GetComponent<Renderer>();
        rMyRenderer.material = mNotPressed;
        // Save the scale of the attached object to a vector.
        vScale = transform.localScale;
        // Get the GateScript component of the 'gate' object reference.
        gateScript = gate.GetComponent<GateScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Change the material.
        rMyRenderer.material = mPressed;
        // Change the scale in the x-direction.
        vScale.x = 0.15f;
        transform.localScale = vScale;
        // Set bool to true (this changes the colour and collisions of the referenced gate).
        gateScript.bIsOpen = true;
    }
}

