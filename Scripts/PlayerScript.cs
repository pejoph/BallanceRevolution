//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: PlayerScript.cs										  /\\
//\  																  /\\
//\  Author  : Peter Phillips										  /\\
//\     															  /\\
//\  Date    : First entry - 20 / 12 / 2017							  /\\
//\     	   Last entry  - 11 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   : Script for moving the player using Unity's input       /\\
//\            mapped controls as well as rotating these controls     /\\
//\            with the camera.                                       /\\
//\            Alse sets the render material for the current player   /\\
//\            state and the corresponding physical properties.       /\\
//\            Also used as the main script for controlling various   /\\
//\            other aspects of the game such as the menus and death  /\\
//\            mechanics.                                             /\\
//\                                                                   /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float fPlayerSpeed;
    public Material mPaper;
    public Material mWood;
    public Material mStone;
    public bool bTransmute;
    public enum MATERIALS
    {
        PAPER,
        WOOD,
        STONE
    }
    public MATERIALS eCurrentMaterial;
    public float fTimer;
    public GameObject direction;
    public Material mSkybox;
    public Vector3 vRespawnPos;
    public GameObject endLevel;
    public Canvas cPauseMenu;
    public Canvas cOptionsMenu;
    public Canvas cLevelComplete;
    public GameObject levelTime;

    private Rigidbody rMyRigidbody;
    private Renderer rMyRenderer;
    private float fHorizontal;
    private float fVertical;
    private Vector3 vMovementDirection;
    private float fDeathTimer;
    private float fRespawnTimer;
    public float fLevelTimer;
    public float fLevelTime;

    private void Start()
    {
        // Start as wood.
        eCurrentMaterial = MATERIALS.WOOD;
        bTransmute = true;
        fTimer = 2.0f;        
        // Set Rigidbody and Renderer values to those of the attached GameObject.
        rMyRigidbody = GetComponent<Rigidbody>();
        rMyRenderer = GetComponent<Renderer>();         
        // Set kinematic to false so that movement works.
        rMyRigidbody.isKinematic = false;
        // Initialise timers.
        fDeathTimer = 0.0f;
        fRespawnTimer = 0.0f;
        fLevelTime = 0.0f;
        // Set the lighting conditions.
        RenderSettings.skybox.SetFloat("_Exposure", 1.5f);
        RenderSettings.ambientIntensity = 1.0f;
        // Set respawn location to start location.
        vRespawnPos = new Vector3(0.0f, 0.5f, 0.0f);
        // Disable all in-game menus.
        cPauseMenu.enabled = false;
        cOptionsMenu.enabled = false;
        cLevelComplete.enabled = false;
        // Set the timescale to the standard value.
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        // Increment level timer (used to display completion time at the end).
        fLevelTimer += Time.deltaTime;
        
        // Brings up / closes menus upon pressing ESC.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!cPauseMenu.enabled && !cOptionsMenu.enabled)
            {
                cPauseMenu.enabled = true;
                Time.timeScale = 0.0f;
            }
            else if (cPauseMenu.enabled)
            {
                cPauseMenu.enabled = false;
                Time.timeScale = 1.0f;
            }
            else if (cOptionsMenu.enabled)
            {
                cOptionsMenu.enabled = false;
                cPauseMenu.enabled = true;
            }
        }

        // Begins death mechanics when player reaches a certain height.
        if (transform.position.y < -8.0f)
        {
            fDeathTimer += Time.deltaTime;    
        }
        // Increases light exposure.
        if (fDeathTimer > 0.0f)
        {
            RenderSettings.skybox.SetFloat("_Exposure", 1.5f + 6.5f * Mathf.Sin(fDeathTimer * Mathf.PI / 2.0f));
            RenderSettings.ambientIntensity = 1.0f + 7.0f * Mathf.Sin(fDeathTimer * Mathf.PI / 2.0f);
        }
        // After a second, player respawns and respawn timer is set to 1.
        if (fDeathTimer >= 1.0f)
        {
            rMyRigidbody.velocity = Vector3.zero;
            transform.position = vRespawnPos;
            transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            fDeathTimer = 0.0f;
            fRespawnTimer = 1.0f;
        }
        // Reduces light exposure back to normal over a second.
        if (fRespawnTimer > 0.0f)
        {
            fRespawnTimer -= 1.0f * Time.deltaTime;
            RenderSettings.skybox.SetFloat("_Exposure", 1.5f + 6.5f * fRespawnTimer); //Mathf.Sin(fRespawnTimer * Mathf.PI / 2.0f));
            RenderSettings.ambientIntensity = 1.0f + 7.0f * fRespawnTimer; //Mathf.Sin(fRespawnTimer * Mathf.PI / 2.0f);
        }
        // Sets light exposure to default value if the timer increments below 0.
        else if (fRespawnTimer < 0.0f)
        {
            RenderSettings.skybox.SetFloat("_Exposure", 1.5f);
            RenderSettings.ambientIntensity = 1.0f;
            fRespawnTimer = 0.0f;
        }

        //// This section is commented out for the actual game.
        //// This is used for testing - numbers 1, 2 and 3 can be pressed to change the player material.
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    eCurrentMaterial = MATERIALS.PAPER;
        //    bTransmute = true;
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    eCurrentMaterial = MATERIALS.WOOD;
        //    bTransmute = true;
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    eCurrentMaterial = MATERIALS.STONE;
        //    bTransmute = true;
        //}

        // Stops player from moving for 2 seconds upon entering a transmuter.
        if (fTimer < 2.0f)
        {
            rMyRigidbody.isKinematic = true;
            fTimer += Time.deltaTime;
        }

        // Changes player material and rigidbody values 2 seconds after player enters a transmuter.
        if (bTransmute && fTimer >= 2.0f)
        {
            if (eCurrentMaterial == MATERIALS.PAPER)
            {
                rMyRigidbody.mass = 4.0f;
                rMyRigidbody.drag = 2.7f;
                rMyRigidbody.angularDrag = 2.7f;

                fPlayerSpeed = 80.0f;

                rMyRenderer.material = mPaper;

                GetComponent<ConstantForce>().force = new Vector3(0.0f, -5.0f, 0.0f);
            }
            else if (eCurrentMaterial == MATERIALS.WOOD)
            {
                rMyRigidbody.mass = 20.0f;
                rMyRigidbody.drag = 0.9f;
                rMyRigidbody.angularDrag = 0.9f;

                fPlayerSpeed = 120.0f;

                rMyRenderer.material = mWood;

                GetComponent<ConstantForce>().force = new Vector3(0.0f, -2.0f, 0.0f);
            }
            else if (eCurrentMaterial == MATERIALS.STONE)
            {
                rMyRigidbody.mass = 100.0f;
                rMyRigidbody.drag = 0.3f;
                rMyRigidbody.angularDrag = 0.3f;

                fPlayerSpeed = 300.0f;

                rMyRenderer.material = mStone;
            }

            rMyRigidbody.isKinematic = false;
            bTransmute = false;
        }        
    }

    private void FixedUpdate()
    {
        // So long as 2 opposing directional keys are not pressed down at the same time and the level is not complete, set the horizontal/vertical components of our movement vector.        
        if (fTimer >= 2 && !((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))) && !endLevel.GetComponent<EndScript>().bLevelComplete)
        {
            fHorizontal = Input.GetAxis("Horizontal");
        }
        else
        {
            fHorizontal = 0.0f;
        }
        if (fTimer >= 2 && !((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))) && !endLevel.GetComponent<EndScript>().bLevelComplete)
        {
            fVertical = Input.GetAxis("Vertical");
        }
        else
        {
            fVertical = 0.0f;
        }
        
        // Set the directional vector for player movement.
        // The Quaternion part rotates the movement direction so that directional input is relative to camera rotation.
        vMovementDirection = Quaternion.Euler(0.0f, direction.transform.eulerAngles.y, 0.0f) * new Vector3(fHorizontal, 0.0f, fVertical);
                
        // Add the resulting force to the attached GameObject - this is determined by the speed which can be changed on the Unity interface.
        rMyRigidbody.AddForce(vMovementDirection * fPlayerSpeed);
    }

    // Called when the continue button is pressed in the pause menu. Pauses game and removes menu.
    public void Continue()
    {
        cPauseMenu.enabled = false;
        Time.timeScale = 1.0f;
    }

    // Called when the restart button is pressed in the pause menu. Restarts game.
    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }

    // Called when the options button is pressed in the pause menu. Removes pause menu and brings up options menu.
    public void Options()
    {
        cPauseMenu.enabled = false;
        cOptionsMenu.enabled = true;
    }

    // Called when the quit button is pressed in the pause menu. Quits game and loads start menu.
    public void Quit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }

    // Called when the close button is pressed in the options menu. Removes options menu and opens pause menu.
    public void Close()
    {
        cPauseMenu.enabled = true;
        cOptionsMenu.enabled = false;
    }

    // Called when the level is complete. Set time taken and begins a coroutine.
    public void EndLevel()
    {
        fLevelTime = Mathf.Floor(fLevelTimer);
        levelTime.GetComponent<Text>().text = "TIME TAKEN: " + fLevelTime + " S";
        StartCoroutine(DisplayEndScreen());
    }

    // Called alongside EndLevel(). Brings up the end-of-level screen after 4 seconds.
    IEnumerator DisplayEndScreen()
    {
        yield return new WaitForSeconds(4.0f);
        cLevelComplete.enabled = true;
    }
}
