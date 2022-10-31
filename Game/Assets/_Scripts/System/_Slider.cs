using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _Slider : MonoBehaviour
{
    Slider slider;
    public bool isMusic;

    MainMenu soundManager;

    private void OnEnable()
    {
        if (slider == null)
            Start();

        //Debug.Log("enable");
        if (isMusic)
            slider.value = MainMenu.VolumeMusic;
        else
            slider.value = MainMenu.VolumeSounds;
    }

    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<MainMenu>();
        slider = GetComponent<Slider>();

        if (isMusic)
            slider.value = MainMenu.VolumeMusic;
        else
            slider.value = MainMenu.VolumeSounds;
    }

    public void UpdateSoundsVolume()
    {
        MainMenu.VolumeSounds = slider.value;
        soundManager.UpdateVolume();
    }

    public void UpdateMusicVolume()
    {
        MainMenu.VolumeMusic = slider.value;
        soundManager.UpdateVolume();
    }
}
