//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: MenuScript.cs    								      /\\
//\  																  /\\
//\  Author  : Peter Phillips										  /\\
//\     															  /\\
//\  Date    : First entry - 09 / 01 / 2018							  /\\
//\     	   Last entry  - 11 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   : Script for controlling the menu screen.                /\\
//\                                                                   /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Button bPlay;
    public Button bOptions;
    public Button bExit;
    public Canvas cExitMenu;
    public Canvas cOptionsMenu;
    public Text tRevolution;
    public Slider sLoading;
    public Text tLoadingPercentage;

    private Color cColourWithAU;
    private float fLoadingIncrement;

    void Start ()
    {
        // Allow use of the on-screen buttons
        bPlay.enabled = true;
        bOptions.enabled = true;
        bExit.enabled = true;
        // Don't display the options or exit menus.
        cExitMenu.enabled = false;
        cOptionsMenu.enabled = false;
        // Initialise the revolution colour.
        cColourWithAU = tRevolution.color;
        // Set the standard timescale (without this nothing is animated in the menu screen if you pause the game and then return to the menu).
        Time.timeScale = 1.0f;
        // Position the loading bar off-screen.
        sLoading.transform.position = new Vector3(sLoading.transform.position.x, -400.0f, sLoading.transform.position.z);
        // Set the loading bar increment to 0%.
        fLoadingIncrement = 0.0f;
    }
    
    void Update ()
    {
        // When escape is pressed, bring up the exit menu - unless a menu is already displaying over the start menu. In which case, close that menu.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!cExitMenu.enabled && !cOptionsMenu.enabled)
            {
                Exit();
            }
            else
            {
                Start();
            }
        }
        // Change the hue of the revolution text over time.
        cColourWithAU = Color.HSVToRGB(Mathf.Repeat(Time.time, 1.0f), 1.0f, 1.0f);
        tRevolution.color = cColourWithAU;
	}

    // Called when the options button is pressed. Disables start menu buttons and brings up the option menu.
    public void Options()
    {
        bPlay.enabled = false;
        bOptions.enabled = false;
        bExit.enabled = false;
        
        cOptionsMenu.enabled = true;
    }
    
    // Called when the options menu is closed. Enables start menu buttons and removes the option menu.
    public void OptionsClose()
    {
        bPlay.enabled = true;
        bOptions.enabled = true;
        bExit.enabled = true;

        cOptionsMenu.enabled = false;
    }
        
    // Called when the exit button is pressed. Disables start menu buttons and brings up the exit menu.
    public void Exit()
    {
        bPlay.enabled = false;
        bOptions.enabled = false;
        bExit.enabled = false;

        cExitMenu.enabled = true;
    }

    // Called when the yes button is pressed on the exit menu. Quits application.
    public void ExitYes()
    {
        Application.Quit();
    }

    // Called when the no button is pressed on the exit menu. Enables start menu buttons and removes the exit menu.
    public void ExitNo()
    {
        bPlay.enabled = true;
        bOptions.enabled = true;
        bExit.enabled = true;

        cExitMenu.enabled = false;
    }

    // Called when the play button is pressed. Disables start menu buttons and moves the loading bar into frame. Also starts a coroutine. 
    public void LoadLevel(int sceneIndex)
    {
        bPlay.enabled = false;
        bOptions.enabled = false;
        bExit.enabled = false;

        sLoading.transform.position = new Vector3(sLoading.transform.position.x, 115.0f, sLoading.transform.position.z);

        StartCoroutine(LoadAsync(sceneIndex));
    }

    // Called alongside LoadLevel(). Starts loading the game level asynchronously and increments the loading bar and percentage.
    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            // In my experience, the level loads instantly (which is 90% of the progress) and then takes about 15 seconds to activate all the necessary files (the other 10%) so here I increase the loading bar percentage by 1% every 1.5 seconds so it doesn't look like the game has crashed.
            fLoadingIncrement += Time.deltaTime;
            sLoading.value = Mathf.Clamp(operation.progress + fLoadingIncrement / 150.0f, 0.0f, 1.0f);            
            tLoadingPercentage.text = Mathf.Floor(100.0f * sLoading.value) + "%";

            yield return null;
        }
    }
}
