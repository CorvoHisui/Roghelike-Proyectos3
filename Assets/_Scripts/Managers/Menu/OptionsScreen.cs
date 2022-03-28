using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsScreen : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;
    private void Start()
    {
        resolutions=Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options=new List<string>();

        int currResolutionIndex=0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width==Screen.currentResolution.width && resolutions[i].height==Screen.currentResolution.height){
                currResolutionIndex=i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value=currResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    public void SetResolution(int resolutionIndex){
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height, Screen.fullScreen);
    }
    public void SetVolume(float volume){

        audioMixer.SetFloat("MainVolume", volume);
        
    }
    public void SetQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullScreen(bool isFullScreen){
        Screen.fullScreen=isFullScreen;
    }
}
