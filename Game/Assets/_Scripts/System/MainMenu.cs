using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MainMenu : MonoBehaviour
{
    public static Action ButtonClicked;

    AudioSource manager;
    public static float VolumeMusic=1;
    public static float VolumeSounds=1;

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().volume = VolumeMusic;    
    }

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<AudioSource>();
    }

    /// <summary>
    /// End game and load <number> Scene
    /// </summary>
    /// <param name="number"></param>
    public void LoadScene(int number)
    {
        Statistics.EndGame();
        SceneManager.LoadScene(number);
    }

    public void MakePause(bool isPause)
    {
        if (isPause)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void UpdateVolume()
    {
        manager.volume = VolumeSounds;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().volume = VolumeMusic;
    }

    public void ButtonClick()
    {
        ButtonClicked?.Invoke();
    }

}
