//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: SettingsScript.cs        							  /\\
//\  																  /\\
//\  Author  : Peter Phillips										  /\\
//\     															  /\\
//\  Date    : First entry - 10 / 01 / 2018							  /\\
//\     	   Last entry  - 10 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   : Script for controlling the options menu with controls  /\\
//\            for resolution, fullscreen and video quality.          /\\
//\                                                                   /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public Dropdown dResolutionDropdown;

    private Resolution[] raResolutions;

	void Start ()
    {
        // Sets our resolutions array to the resolutions of the screen in use.
        raResolutions = Screen.resolutions;

        // Clears my test values.
        dResolutionDropdown.ClearOptions();

        // Creates list of strings to store resolution names.
        List<string> slOptions = new List<string>();

        // Create index used to show the current screen resolution when launching the game.
        int iCurrentResolutionIndex = 0;
        // Loop through the resolutions and update our string list. 
        for (int i = 0; i < raResolutions.Length; i++)
        {
            string sOption = raResolutions[i].width + " x " + raResolutions[i].height;
            slOptions.Add(sOption);

            // When the current resolution is found, store that index value.
            if (raResolutions[i].width == Screen.currentResolution.width && raResolutions[i].height == Screen.currentResolution.height)
            {
                iCurrentResolutionIndex = i;
            }
        }

        // Add all the elements of our list to the dropdown in the menu.
        dResolutionDropdown.AddOptions(slOptions);
        // Set the currently displayed value to the current screen resolution.
        dResolutionDropdown.value = iCurrentResolutionIndex;
        // Refresh the value so it displays correctly.
        dResolutionDropdown.RefreshShownValue();
	}	

    // Called when the quality dropdown is adjusted. Changes the video quality.
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    // Called when the fullscreen toggle is pressed. Maximises/middlemises (yes, that's now a word) the game window.
    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    // Called when the resolution dropdown is adjusted. Changes the resolution.
    public void SetResolution (int resolutionIndex)
    {
        Screen.SetResolution(raResolutions[resolutionIndex].width, raResolutions[resolutionIndex].height, Screen.fullScreen);
    }
}
