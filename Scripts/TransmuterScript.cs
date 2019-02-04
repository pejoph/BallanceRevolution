//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: TransmuterScript.cs								      /\\
//\  																  /\\
//\  Author  : Peter Phillips										  /\\
//\     															  /\\
//\  Date    : First entry - 05 / 01 / 2018							  /\\
//\     	   Last entry  - 05 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   : Script for controlling the mechanics and animation     /\\
//\            of transmutation.                                      /\\
//\                                                                   /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmuterScript : MonoBehaviour
{
    public GameObject Player;
    public PlayerScript.MATERIALS material;
    public GameObject Scanner;

    private PlayerScript playerScript;
    private Vector3 vPosition;
    private Vector3 vScannerPosition;
    private float fTimeNorm;
    private float fTimer;
    private float fMeanHeight;

    void Start ()
    {
        // Get the player script component attached to the referenced player object.
        playerScript = Player.GetComponent<PlayerScript>();
        // Store a position 0.5 higher in the y-direction to that of the attached object.
        vPosition = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        // Initialise the scanner position.
        vScannerPosition = Scanner.transform.position;
        // Initialise animation timer.
        fTimer = 2.0f;
        // Set the mean height of the scanner animation.
        fMeanHeight = transform.position.y + .55f;
    }

    private void OnTriggerEnter(Collider other)
    {
        // As long as the player is a different material to that of the transmuter, change the player meterial, set the boolean to true (this stops player from moving) and reset timers.
        // Also move the player into the transmuter and set a reference value to the game time (used in the scanner animation).
        if (playerScript.eCurrentMaterial != material)
        {
            playerScript.eCurrentMaterial = material;
            playerScript.bTransmute = true;
            playerScript.fTimer = 0.0f;
            fTimer = 0.0f;

            other.transform.position = vPosition;
            fTimeNorm = Time.time;
        }        
    }
    
    private void Update()
    {
        // Animate the scanner up and down for 2 seconds following simple harmonic motion
        if (fTimer < 2)
        {
            vScannerPosition.y = fMeanHeight - .5f * Mathf.Cos((Time.time - fTimeNorm) * Mathf.PI);
            Scanner.transform.position = vScannerPosition;
            fTimer += Time.deltaTime;
        }
    }
}
