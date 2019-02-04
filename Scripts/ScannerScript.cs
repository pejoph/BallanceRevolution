//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: ScannerScript.cs	    							      /\\
//\  																  /\\
//\  Author  : Peter Phillips										  /\\
//\     															  /\\
//\  Date    : First entry - 05 / 01 / 2018							  /\\
//\     	   Last entry  - 05 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   :      THIS SCRIPT IS OBSELETE                           /\\
//\                                                                   /\\
//\                                                                   /\\
//\                                                                   /\\
//\                                                                   /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerScript : MonoBehaviour
{
    public GameObject Player;

    private PlayerScript playerScript;
    private Vector3 vPosition;
    private float fMeanHeight;

    // Use this for initialization
    void Start ()
    {
        playerScript = Player.GetComponent<PlayerScript>();
        vPosition = transform.position;
        fMeanHeight = transform.position.y + 1000.5f;
    }

    // Update is called once per frame
    void Update ()
    {
		if (playerScript.fTimer < 2)
        {
            vPosition.y = fMeanHeight - .5f * Mathf.Cos(Time.time * Mathf.PI);
            transform.position = vPosition;
        }
	}
}
