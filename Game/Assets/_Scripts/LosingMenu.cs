using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

using UnityEngine.Events;

public class LosingMenu : MonoBehaviour
{
    [SerializeField] GameObject Points;
    [SerializeField] GameObject Record;
    [SerializeField] GameObject New_Record;
    [SerializeField] GameObject button;
    public GameObject loseMenu;

    //[SerializeField] private UnityEvent _event;
    
    public static Action LoseMenuActivate;
    private void Awake()
    {
        HealthSlider.EndHP += Activate;
        YG.YandexGame.CloseVideoEvent += ResumeGame;

        /*public static UnityEvent Event = new();
    Event?.Invoke();
        LosingMenu.Event.AddListener(ButtonClick);*/
    }

    void Activate()
    {
        loseMenu.SetActive(true);
        MainMenu.MakePause(true);
        Debug.Log("Activate");

        Points.GetComponent<TextMeshProUGUI>().text = string.Format("Ваш результат: {0}", Statistics.GameCount);
        Record.GetComponent<TextMeshProUGUI>().text = string.Format("Ваш рекорд: {0}", YG.YandexGame.savesData.RecordCount);

        if (Statistics.GameCount > YG.YandexGame.savesData.RecordCount)        {
            New_Record.GetComponent<TextMeshProUGUI>().text = string.Format("Ура! Новый рекорд!");
        }
        else if (Statistics.GameCount > (YG.YandexGame.savesData.RecordCount * 0.87f)){
            New_Record.GetComponent<TextMeshProUGUI>().text = string.Format("Ты так близко...");
        }
        else
        {
            New_Record.GetComponent<TextMeshProUGUI>().text = string.Format("Попробуй еще раз!");
        }

        button.SetActive(!Statistics.HelpVideoEndGet);
    }

    public void ResumeGame()
    {
        YG.YandexGame.RewVideoShow(0);
    }

    void ResumeGame(int u)
    {
        if (u == 0)
        {
            loseMenu.SetActive(false);
            MainMenu.MakePause(false);

            LoseMenuActivate?.Invoke();
            Statistics.HelpVideoEndGet = true;
        }

    }
}
