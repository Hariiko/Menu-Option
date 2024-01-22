using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogicalCalidad : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown qualityDropdown;

    private void Start()
    {
        PopulateQualityDropdown();
    }

    private void PopulateQualityDropdown()
    {
        List<string> qualityOptions = new List<string>(QualitySettings.names);
        qualityDropdown.ClearOptions();
        qualityDropdown.AddOptions(qualityOptions);

        // Set the initial value based on the current quality level
        qualityDropdown.value = QualitySettings.GetQualityLevel();
        qualityDropdown.RefreshShownValue();
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
