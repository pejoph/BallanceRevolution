//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: SignScript.cs    								      /\\
//\  																  /\\
//\  Author  : Peter Phillips										  /\\
//\     															  /\\
//\  Date    : First entry - 06 / 01 / 2018							  /\\
//\     	   Last entry  - 09 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   : Script for displaying the message above a sign with    /\\
//\            an alpha value dependent on the player's distance      /\\
//\            from the sign. Also rotates the message according to   /\\
//\            the camera direction.                                  /\\
//\                                                                   /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignScript : MonoBehaviour
{
    public GameObject direction;
    public Collider player;

    private TextMesh myTextMesh;
    private Color cColourWithAU;
    
    
	void Start ()
    {
        // Get the text mesh of the attached object.
        myTextMesh = GetComponent<TextMesh>();
        // Set the stored colour to the current colour but the alpha to 0.
        cColourWithAU = myTextMesh.color;
        cColourWithAU.a = 0.0f;
        // Set the attached object's colour to our new invisible colour.
        myTextMesh.color = cColourWithAU;
    }
	
    private void OnTriggerStay(Collider other)
    {
        // Changes the opacity of the text to it's 100% when the player is within 2m (assuming unity distance units are metres) of the sign and fades to 0% between 2m and 4m.
        cColourWithAU.a = 2.0f - .5f * Vector3.Distance(player.transform.position, transform.position);
        myTextMesh.color = cColourWithAU;
    }

    private void LateUpdate()
    {
        // Rotates the text to follow the camera direction so it's always readable.
        transform.rotation = direction.transform.rotation;
    }
}
