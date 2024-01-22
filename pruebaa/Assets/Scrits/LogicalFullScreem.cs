using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogicalFullSceem : MonoBehaviour
{
    public Toggle toggle;
    public TMP_Dropdown resolucionesDropDown;
    Resolution[] resolutiones;
    void Start()
    {
        if(Screen.fullScreen)
            toggle.isOn = true;
        else
            toggle.isOn = false;
        RevisarResolucion();
    }

    public void ActivateScreenComplet(bool screenComplate)
    { 
        Screen.fullScreen = screenComplate;
    }

    public void RevisarResolucion()
    {
        resolutiones = Screen.resolutions;
        resolucionesDropDown.ClearOptions();
        List<string> opciones = new List<string>();
        int resolucionActual = 0;
        
        for (int i = 0; i < resolutiones.Length; i++)
        { 
            string opcion = resolutiones[i].width + "x" + resolutiones[i].height;  
            opciones.Add(opcion);

            if (Screen.fullScreen && resolutiones[i].width == Screen.currentResolution.width &&
                resolutiones[i].height == Screen.currentResolution.height)

            {
                resolucionActual = i;
            }
            resolucionesDropDown.AddOptions(opciones);
            resolucionesDropDown.value = resolucionActual;
            resolucionesDropDown.RefreshShownValue();
            resolucionesDropDown.value = PlayerPrefs.GetInt("numResolucion", 0);
        }
    }

    public void CambiarResolucion(int indiceResolucion)
    {
        PlayerPrefs.SetInt("numResolucion", resolucionesDropDown.value);
        Resolution resolution = resolutiones[indiceResolucion];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}