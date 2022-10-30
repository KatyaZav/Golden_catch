using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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



}
