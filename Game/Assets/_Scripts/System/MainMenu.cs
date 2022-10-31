using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    AudioSource manager;
    public static float VolumeMusic=1;
    public static float VolumeSounds=1;

    private void Start()
    {
        manager = GetComponent<AudioSource>();
    }
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


}
