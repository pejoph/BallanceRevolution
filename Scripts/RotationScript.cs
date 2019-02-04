//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: RotationScript.cs        							  /\\
//\  																  /\\
//\  Author  : Peter Phillips										  /\\
//\     															  /\\
//\  Date    : First entry - 08 / 01 / 2018							  /\\
//\     	   Last entry  - 08 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   : Script for displaying the checkpoint reached message   /\\
//\            and rotating it to follow the camera direction.        /\\
//\                                                                   /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{ 
    public GameObject direction;
    public GameObject checkpoint;

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
	
	void Update ()
    {
        // If the checkpoint has been reached for the first time then the timer will be set to 4 so the hue changes from 1 to 0 and the alpha is set to 1 for 2 seconds then incrementally drops to 0 for the next 2 seconds.
        if (checkpoint.GetComponent<CheckpointScript>().fTimer > 0)
        {
            checkpoint.GetComponent<CheckpointScript>().fTimer -= Time.deltaTime;
            cColourWithAU = Color.HSVToRGB(checkpoint.GetComponent<CheckpointScript>().fTimer / 4.0f, 1.0f, 1.0f);
            cColourWithAU.a = checkpoint.GetComponent<CheckpointScript>().fTimer / 2.0f;
            myTextMesh.color = cColourWithAU;
        }
    }

    private void LateUpdate()
    {
        // Rotates the text to follow the camera direction so it's always readable.
        transform.rotation = direction.transform.rotation;
    }
}
