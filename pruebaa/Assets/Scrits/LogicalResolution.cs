using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogicalResolution : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;
    private List<string> options;
    private List<string> uniqueResolutions;
    private int currentResolutionIndex = 0;

    private void Start()
    {
        options = new List<string>();
        uniqueResolutions = new List<string>();
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string resolutionOption = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + " Hz";

            // Check if the resolutionOption is not already in the list
            if (!uniqueResolutions.Contains(resolutionOption))
            {
                uniqueResolutions.Add(resolutionOption);
                options.Add(resolutionOption);

                if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
                    currentResolutionIndex = uniqueResolutions.Count - 1; // Set the index based on unique resolutions
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        // Use resolutions array directly for setting resolution
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);
    }
}
