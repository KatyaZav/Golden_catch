using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achivements : MonoBehaviour
{    
    public GameObject GetGoldAchive;
    public GameObject GetWasGame;
    public GameObject GetAchives;

    void Start()
    {
        if (YG.YandexGame.savesData.isGetGold)
            GetGoldAchive.SetActive(true);
        if (YG.YandexGame.savesData.isWasGame)
            GetWasGame.SetActive(true);
        if (YG.YandexGame.savesData.isWasGame && YG.YandexGame.savesData.isGetGold)
            GetAchives.SetActive(true);
    }
}
