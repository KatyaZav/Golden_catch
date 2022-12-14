using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LosingMenu : MonoBehaviour
{
    [SerializeField] GameObject Points;
    [SerializeField] GameObject Record;
    [SerializeField] GameObject New_Record;
    [SerializeField] GameObject Main_Menu;
    [SerializeField] GameObject button;

    public static Action LoseMenuActivate;
    private void Awake()
    {
        HealthSlider.EndHP += Activate;
        gameObject.SetActive(false);
        YG.YandexGame.CloseVideoEvent += ResumeGame;
    }

    void Activate()
    {
        gameObject.SetActive(true);
        Main_Menu.GetComponent<MainMenu>().MakePause(true);
        Debug.Log("Activate");

        Points.GetComponent<TextMeshProUGUI>().text = string.Format("��� ���������: {0}", Statistics.GameCount);
        Record.GetComponent<TextMeshProUGUI>().text = string.Format("��� ������: {0}", YG.YandexGame.savesData.RecordCount);

        if (Statistics.GameCount > YG.YandexGame.savesData.RecordCount)        {
            New_Record.GetComponent<TextMeshProUGUI>().text = string.Format("���! ����� ������!");
        }
        else if (Statistics.GameCount > (YG.YandexGame.savesData.RecordCount * 0.87f)){
            New_Record.GetComponent<TextMeshProUGUI>().text = string.Format("�� ��� ������...");
        }
        else
        {
            New_Record.GetComponent<TextMeshProUGUI>().text = string.Format("�������� ��� ���!");
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
            gameObject.SetActive(false);
            Main_Menu.GetComponent<MainMenu>().MakePause(false);

            LoseMenuActivate?.Invoke();
            Statistics.HelpVideoEndGet = true;
        }

    }
}
