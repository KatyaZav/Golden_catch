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
        UpdateSliderValue();
    }

    void UpdateSliderValue()
    {
        if (isMusic)
            slider.value = YG.YandexGame.savesData.MusicVolume;
        else
            slider.value = YG.YandexGame.savesData.SoundVolume;
    }

    void Awake()
    {
        soundManager = GameObject.FindGameObjectWithTag("MainMenu").GetComponent<MainMenu>();
        slider = GetComponent<Slider>();

        UpdateSliderValue();
    }

    public void UpdateSoundsVolume()
    {
        YG.YandexGame.savesData.SoundVolume = slider.value;
        YG.YandexGame.SaveProgress();

        SoundManager.Manager.UpdateVolume();
    }

    public void UpdateMusicVolume()
    {
        YG.YandexGame.savesData.MusicVolume = slider.value;
        YG.YandexGame.SaveProgress();

        SoundManager.Manager.UpdateVolume();
    }
}
