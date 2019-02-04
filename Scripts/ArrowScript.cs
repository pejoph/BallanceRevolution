//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: ArrowScript.cs										  /\\																		
//\  																  /\\															
//\  Author  : Peter Phillips										  /\\															
//\     															  /\\																
//\  Date    : First entry - 02 / 01 / 2018							  /\\															
//\     	   Last entry  - 09 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   : Script for displaying and transforming the arrows      /\\
//\            used to indicate movement direction at the beginning   /\\
//\            of the level.                                          /\\
//\                                                                   /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public GameObject player;
    public GameObject RightArrow;
    public GameObject LeftArrow;
    public GameObject UpArrow;
    public GameObject DownArrow;
    public GameObject direction;
    public GameObject arrows;
    public Material Transparent;
    public bool bProgress;

    private Vector3 vArrowPosition;
    private Vector3 vRightArrowScale;
    private Vector3 vLeftArrowScale;
    private Vector3 vUpArrowScale;
    private Vector3 vDownArrowScale;
    private float fAlpha;

    private void Start()
    {
        // Initialise our vector for the 'arrows' parent position at 0, 0.5, 0 (The player starting positon).
        vArrowPosition = new Vector3(0.0f, 0.5f, 0.0f);

        // Initialise all the arrow scales to 1, 1, 1.
        vRightArrowScale = new Vector3 (1.0f, 1.0f, 1.0f);
        vLeftArrowScale = new Vector3 (1.0f, 1.0f, 1.0f);
        vUpArrowScale = new Vector3 (1.0f, 1.0f, 1.0f);
        vDownArrowScale = new Vector3 (1.0f, 1.0f, 1.0f);

        // Initialise the opacity and colour of the material and state that the player has not left the first area.
        fAlpha = .5f;
        Transparent.color = new Color(1.0f, 1.0f, 1.0f, .5f);
        bProgress = false;
    }

    private void Update()
    {
        // If player has left the first area, reduce the opacity of the arrows and remove them after 10 seconds.
        if (bProgress)
        {
            if (fAlpha > 0)
            {
                Transparent.color = new Color(1.0f, 1.0f, 1.0f, fAlpha);
                fAlpha -= Time.deltaTime / 20.0f;
            }
            else
            {
                Destroy(arrows);
            }
        }

        // Stretches the arrows when directional keys are pressed.
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (vRightArrowScale.z < 1.5f)
            {
                vRightArrowScale.z += 4 * Time.deltaTime;
                vRightArrowScale.x += 2 * Time.deltaTime;
            }
            // Stops the value from going too high if there is a large increment.
            if (vRightArrowScale.z > 1.5f)
            {
                vRightArrowScale.z = 1.5f;
                vRightArrowScale.x = 1.25f;
            }

            RightArrow.transform.localScale = vRightArrowScale;
        }
        // Shrinks the arrows back when directional keys are released.
        else
        {
            if (vRightArrowScale.z > 1.0f)
            {
                vRightArrowScale.z -= 8 * Time.deltaTime;
                vRightArrowScale.x -= 4 * Time.deltaTime;
            }
            // Stops the value from going too low if there is a large increment.
            if (vRightArrowScale.z < 1.0f)
            {
                vRightArrowScale.z = 1.0f;
                vRightArrowScale.x = 1.0f;
            }

            RightArrow.transform.localScale = vRightArrowScale;
        }        

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (vLeftArrowScale.z < 1.5f)
            {
                vLeftArrowScale.z += 4 * Time.deltaTime;
                vLeftArrowScale.x += 2 * Time.deltaTime;
            }
            if (vLeftArrowScale.z > 1.5f)
            {
                vLeftArrowScale.z = 1.5f;
                vLeftArrowScale.x = 1.25f;
            }

            LeftArrow.transform.localScale = vLeftArrowScale;
        }
        else
        {
            if (vLeftArrowScale.z > 1.0f)
            {
                vLeftArrowScale.z -= 8 * Time.deltaTime;
                vLeftArrowScale.x -= 4 * Time.deltaTime;
            }
            if (vLeftArrowScale.z < 1.0f)
            {
                vLeftArrowScale.z = 1.0f;
                vLeftArrowScale.x = 1.0f;
            }

            LeftArrow.transform.localScale = vLeftArrowScale;
        }
        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (vUpArrowScale.z < 1.5f)
            {
                vUpArrowScale.z += 4 * Time.deltaTime;
                vUpArrowScale.x += 2 * Time.deltaTime;
            }
            if (vUpArrowScale.z > 1.5f)
            {
                vUpArrowScale.z = 1.5f;
                vUpArrowScale.x = 1.25f;
            }

            UpArrow.transform.localScale = vUpArrowScale;
        }
        else
        {
            if (vUpArrowScale.z > 1.0f)
            {
                vUpArrowScale.z -= 8 * Time.deltaTime;
                vUpArrowScale.x -= 4 * Time.deltaTime;
            }
            if (vUpArrowScale.z < 1.0f)
            {
                vUpArrowScale.z = 1.0f;
                vUpArrowScale.x = 1.0f;
            }

            UpArrow.transform.localScale = vUpArrowScale;
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (vDownArrowScale.z < 1.5f)
            {
                vDownArrowScale.z += 4 * Time.deltaTime;
                vDownArrowScale.x += 2 * Time.deltaTime;
            }
            if (vDownArrowScale.z > 1.5f)
            {
                vDownArrowScale.z = 1.5f;
                vDownArrowScale.x = 1.25f;
            }

            DownArrow.transform.localScale = vDownArrowScale;
        }
        else
        {
            if (vDownArrowScale.z > 1.0f)
            {
                vDownArrowScale.z -= 8 * Time.deltaTime;
                vDownArrowScale.x -= 4 * Time.deltaTime;
            }
            if (vDownArrowScale.z < 1.0f)
            {
                vDownArrowScale.z = 1.0f;
                vDownArrowScale.x = 1.0f;
            }

            DownArrow.transform.localScale = vDownArrowScale;
        }

        // Update our vector with the player position.
        vArrowPosition.x = player.transform.position.x;
        vArrowPosition.y = player.transform.position.y;
        vArrowPosition.z = player.transform.position.z;
    }

    void LateUpdate()
    {
        // Update the 'arrows' parent position so that it tracks the player.
        transform.position = vArrowPosition;
        // Rotate arrows according to camera rotation.
        transform.eulerAngles = direction.transform.eulerAngles;
    }
}
