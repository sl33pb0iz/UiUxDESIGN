using Doozy.Runtime.UIManager.Components;
using Hellmade.Sound;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterSoundController : MonoBehaviour
{
    public EazySoundDemoAudioControls[] AudioControls;
    public UISlider globalMusicVolSlider;
    public UISlider globalSoundVolSlider;

    private void OnEnable()
    {
        globalMusicVolSlider.OnValueChanged.AddListener(GlobalMusicVolumeChanged);
        globalSoundVolSlider.OnValueChanged.AddListener(GlobalSoundVolumeChanged);
    }

    private void OnDisable()
    {
        globalMusicVolSlider.OnValueChanged.RemoveListener(GlobalMusicVolumeChanged);
        globalSoundVolSlider.OnValueChanged.RemoveListener(GlobalSoundVolumeChanged);
    }

    public void GlobalMusicVolumeChanged(float value)
    {
        EazySoundManager.GlobalMusicVolume = value;
    }

    public void GlobalSoundVolumeChanged(float value)
    {
        EazySoundManager.GlobalSoundsVolume = value;
        EazySoundManager.GlobalUISoundsVolume = value;
    }



}
