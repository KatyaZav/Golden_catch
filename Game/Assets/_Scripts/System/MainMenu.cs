using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MainMenu : MonoBehaviour
{
    public static Action ButtonClicked;

    /// <summary>
    /// End game and load <number> Scene
    /// </summary>
    /// <param name="number"></param>
    public void EndGameAndLoadScene(int number)
    {
        Statistics.EndGame();
        SceneManager.LoadScene(number);
    }

    public static void MakePause(bool isPause)
    {
        if (isPause)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }  

    public void ButtonClick()
    {
        ButtonClicked?.Invoke();
    }    
}
